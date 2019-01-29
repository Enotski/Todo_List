using System;
using System.ComponentModel;
using Todo_List.Models;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Todo_List.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        private ToDoTask _selectedTodo;
        public ObservableCollection<ToDoTask> TodoCollection { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        ToDoTask todo = new ToDoTask();
                        todo.Order = TodoCollection.Count + 1;
                        TodoCollection.Add(todo);
                    }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand(obj =>
                    {
                        ToDoTask todo = obj as ToDoTask;
                        if(todo != null)
                        {
                            TodoCollection.Remove(todo);
                        }
                    }, (obj) => TodoCollection.Count > 0));
            }
        }

        public ToDoTask SelectedTodo
        {
            get { return _selectedTodo; }
            set
            {
                _selectedTodo = value;
                OnPropertyChanged("SelectedTodo");
            }
        }
        public TodoViewModel()
        {
            TodoCollection = new ObservableCollection<ToDoTask>()
            {
                new ToDoTask { ToDo = "Something", Vital = true, SettedDate = DateTime.Today, Order = 1 },
               new ToDoTask { ToDo = "Something_1", Vital = true, SettedDate = DateTime.Today, Order = 2 },
                new ToDoTask { ToDo = "Something_2", Vital = false, SettedDate = DateTime.Today, Order = 3 }
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
