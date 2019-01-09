using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Todo_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _completedCounter;
        XDocument xDoc;
        XElement xElemRoot;
        ObservableCollection<Task> _tascksCollection;
        public MainWindow()
        {
            InitializeComponent();
            _tascksCollection = new ObservableCollection<Task>();
            TaskList.ItemsSource = _tascksCollection;
            UpdateTaskList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                Task tsk = TaskList.SelectedItem as Task;
                TaskEditor editor = new TaskEditor() { DataContext = tsk };
                TaskEditorControlWindow c_window = new TaskEditorControlWindow(editor);
                c_window.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Task tsk = new Task();
            TaskEditor t_edit = new TaskEditor() { DataContext = tsk };
            TaskEditorControlWindow c_Window = new TaskEditorControlWindow(t_edit);
            if (c_Window.ShowDialog().Value)
            {
                _tascksCollection.Add(tsk);
                UpdateTaskList();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                Task tsk = TaskList.SelectedItem as Task;
                _tascksCollection.Remove(tsk);
                UpdateTaskList();
            }
        }
        private void UpdateTaskList()
        {
            foreach (var item in _tascksCollection)
            {
                item.Counter = _tascksCollection.IndexOf(item) + 1;
            }
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                Task tsk = TaskList.SelectedItem as Task;
                _tascksCollection.Remove(tsk);
                UpdateTaskList();
                CompletedCount.Text = (++_completedCounter).ToString();

                xDoc = XDocument.Load("TasksLocalHistory.xml");
                xElemRoot = xDoc.Element("tasks");
                xElemRoot.Add(new XElement("task",
                        new XAttribute("todo", tsk.ToDo),
                        new XElement("settedDate", tsk.SettedDate),
                        new XElement("vital", tsk.Vital)));
                xDoc.Save("TasksLocalHistory.xml");
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            xDoc = XDocument.Load("TasksLocal.xml");
            xElemRoot = xDoc.Element("tasks");
            xElemRoot.RemoveNodes();
            foreach (Task tsk in _tascksCollection)
            {
                xElemRoot.Add(new XElement("task",
                    new XAttribute("todo", tsk.ToDo),
                    new XElement("settedDate", tsk.SettedDate),
                    new XElement("vital", tsk.Vital)));
            }
            xDoc.Save("TasksLocal.xml");
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            xDoc = XDocument.Load("TasksLocal.xml");
            foreach (var xTask in xDoc.Element("tasks").Elements())
            {
                XAttribute attribute = xTask.Attribute("todo");
                XElement dateElem = xTask.Element("settedDate");
                XElement vitalElem = xTask.Element("vital");
                if (attribute != null && dateElem != null && vitalElem != null)
                {
                    if (_tascksCollection.Where(tsk => tsk.ToDo == attribute.Value).Count() == 0)
                    {
                        _tascksCollection.Add(new Task
                        {
                            ToDo = attribute.Value,
                            SettedDate = DateTime.Parse(dateElem.Value),
                            Vital = Boolean.Parse(vitalElem.Value),
                            Counter = _tascksCollection.Count + 1
                        });
                    }
                }
            }
        }
    }
}
