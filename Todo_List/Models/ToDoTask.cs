using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Todo_List.Models
{
    public class ToDoTask : INotifyPropertyChanged
    {
        private string _toDo;
        private DateTime _settedDate;
        private bool _vital;
        private int _order;

        [Display(Name = "Task")]
        [Required()]
        public string ToDo
        {
            get { return _toDo; }
            set
            {
                _toDo = value;
                OnPropertyChanged("ToDo");
            }
        }
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