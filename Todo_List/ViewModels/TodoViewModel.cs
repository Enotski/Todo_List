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
               new ToDoTask { ToDo="Get a work as Mr/Xr UI/UX developer", Vital=true, SettedDate = DateTime.Today, Order=1 },
               new ToDoTask { ToDo="Become needful", Vital=true, SettedDate = DateTime.Today, Order=2 },
                new ToDoTask { ToDo="Buy a pretty house", Vital=false, SettedDate = DateTime.Today, Order=3 },
              new ToDoTask { ToDo="Become financial independetly", Vital=true, SettedDate = DateTime.Today, Order=4 },
              new ToDoTask { ToDo="Don`t think about stupid things", Vital=false, SettedDate = DateTime.Today, Order=5 },
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
