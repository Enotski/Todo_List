using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.IO;
using System.Windows.Media;

namespace Todo_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ToDoTask> _tascksCollection;

        public MainWindow()
        {
            InitializeComponent();
            _tascksCollection = new ObservableCollection<ToDoTask>();
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            _tascksCollection.Add(new ToDoTask { ToDo = "something", SettedDate = DateTime.Now, Vital = false });
            TaskList.ItemsSource = _tascksCollection;
            UpdateTaskList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ToDoTask tsk = new ToDoTask();
            TaskEditor t_edit = new TaskEditor() { DataContext = tsk };
            TaskEditorControlWindow c_Window = new TaskEditorControlWindow(t_edit);
            if (c_Window.ShowDialog().Value)
            {
                _tascksCollection.Add(tsk);
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
                //filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"LocalStorage\", localHistoryFile);

                ToDoTask tsk = TaskList.SelectedItem as ToDoTask;
                _tascksCollection.Remove(tsk);
                UpdateTaskList();

                //xDoc = XDocument.Load(filePath);
                //xElemRoot = xDoc.Element("tasks");
                //xElemRoot.Add(new XElement("task",
                //        new XAttribute("todo", tsk.ToDo),
                //        new XElement("settedDate", tsk.SettedDate),
                //        new XElement("vital", tsk.Vital)));
                //xDoc.Save(filePath);
            }
        }

        //private void SaveFile_Click(object sender, RoutedEventArgs e)
        //{
        //    filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"LocalStorage\", localTasksFile);
        //    xDoc = XDocument.Load(filePath);
        //    xElemRoot = xDoc.Element("tasks");
        //    xElemRoot.RemoveNodes();
        //    foreach (ToDoTask tsk in _tascksCollection)
        //    {
        //        xElemRoot.Add(new XElement("task",
        //            new XAttribute("todo", tsk.ToDo),
        //            new XElement("settedDate", tsk.SettedDate),
        //            new XElement("vital", tsk.Vital)));
        //    }
        //    xDoc.Save(filePath);
        //}

        //private void LoadFile_Click(object sender, RoutedEventArgs e)
        //{
        //    filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"LocalStorage\", localTasksFile);
        //    xDoc = XDocument.Load(filePath);
        //    foreach (var xTask in xDoc.Element("tasks").Elements())
        //    {
        //        XAttribute attribute = xTask.Attribute("todo");
        //        XElement dateElem = xTask.Element("settedDate");
        //        XElement vitalElem = xTask.Element("vital");
        //        if (attribute != null && dateElem != null && vitalElem != null)
        //        {
        //            if (_tascksCollection.Where(tsk => tsk.ToDo == attribute.Value).Count() == 0)
        //            {
        //                _tascksCollection.Add(new ToDoTask
        //                {
        //                    ToDo = attribute.Value,
        //                    SettedDate = DateTime.Parse(dateElem.Value),
        //                    Vital = Boolean.Parse(vitalElem.Value),
        //                    Counter = _tascksCollection.Count + 1
        //                });
        //            }
        //        }
        //    }
        //}

        private void editTask(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(TaskList.SelectedItem != null)
            {
                ToDoTask tsk = TaskList.SelectedItem as ToDoTask;
                TaskEditor editor = new TaskEditor() { DataContext = tsk };
                TaskEditorControlWindow c_window = new TaskEditorControlWindow(editor);
                c_window.ShowDialog();
            }
        }

    }
}
