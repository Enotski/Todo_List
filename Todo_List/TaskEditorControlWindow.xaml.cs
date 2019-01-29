using System.Windows;
using Todo_List.Models;


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
    }
}
