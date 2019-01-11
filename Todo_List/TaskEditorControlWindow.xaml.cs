using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel.DataAnnotations;

namespace Todo_List
{
    /// <summary>
    /// Логика взаимодействия для TaskEditorControlWindow.xaml
    /// </summary>
    public partial class TaskEditorControlWindow : Window
    {
        FrameworkElement _controlForShow = null;
        public ToDoTask newTask;
        public TaskEditorControlWindow(FrameworkElement t_controlForShow)
        {
            InitializeComponent();
            _controlForShow = t_controlForShow;
            TaskEditor.Content = t_controlForShow;
        }
        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            List<string> requiredPropertyNames = new List<string>();

            List<Control> propertyControls = GetChildControls(_controlForShow);

            List<BindingExpression> expressions = new List<BindingExpression>();

            Type buisnessObjectType = _controlForShow.DataContext.GetType();
            foreach (var current in propertyControls)
            {
                BindingExpression expression = null;

                if (current is TextBox)
                {
                    expression = (current as TextBox).GetBindingExpression(TextBox.TextProperty);
                    expressions.Add(expression);
                    PropertyInfo property = buisnessObjectType.GetProperty(expression.ParentBinding.Path.Path);
                    Attribute attr = property.GetCustomAttribute(typeof(RequiredAttribute));
                    if (string.IsNullOrWhiteSpace((current as TextBox).Text))
                    {
                        string propertyName = property.Name;
                        Attribute description = property.GetCustomAttribute(typeof(DisplayAttribute));
                        if (description != null)
                        {
                            propertyName = (description as DisplayAttribute).Name;
                        }
                        requiredPropertyNames.Add(propertyName);
                    }
                }
                else if (current is CheckBox)
                    expression = (current as CheckBox).GetBindingExpression(CheckBox.IsCheckedProperty);
                else if (current is Calendar)
                    expression = (current as Calendar).GetBindingExpression(Calendar.DataContextProperty);
            }
            if (requiredPropertyNames.Count == 0)
            {
                foreach (var exp in expressions)
                {
                    exp.UpdateSource();
                }
                DialogResult = true;
            }
            else
            {
                TaskList.ItemsSource = requiredPropertyNames;
                ErrorMsg.Visibility = Visibility.Visible;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                ToDoTask tsk = TaskList.SelectedItem as ToDoTask;
                TaskList.Items.Remove(tsk);
            }
            DialogResult = true;
        }

        private List<Control> GetChildControls(object currentControl)
        {
            List<Control> resultControls = new List<Control>();
            if (currentControl is TextBox)
                resultControls.Add(currentControl as TextBox);
            else if (currentControl is CheckBox)
                resultControls.Add(currentControl as CheckBox);
            else if (currentControl is Calendar)
                resultControls.Add(currentControl as Calendar);
            else if (currentControl is ContentControl)
                resultControls = GetChildControls((currentControl as ContentControl).Content);

            else if (currentControl is Panel)
            {
                foreach (var chld in (currentControl as Panel).Children)
                {
                    List<Control> chldCollection = GetChildControls(chld);
                    resultControls.AddRange(chldCollection);
                }
            }
            return resultControls;
        }
    }
}
