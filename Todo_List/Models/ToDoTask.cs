using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Todo_List.Models
{
    public class ToDoTask : INotifyPropertyChanged
    {
        private string _toDo;
        private DateTime _settedDate;
        private bool _vital;
        private int _order;

        public string ToDo
        {
            get { return _toDo; }
            set
            {
                _toDo = value;
                OnPropertyChanged("ToDo");
            }
        }

        // Deadline date
        public DateTime SettedDate
        {
            get { return _settedDate; }
            set
            {
                _settedDate = value;
                OnPropertyChanged("SettedDate");
            }
        }
        public bool Vital
        {
            get { return _vital; }
            set
            {
                _vital = value;
                OnPropertyChanged("Vital");
            }
        }

        // Order in tasks collection
        public int Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged("Order");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}