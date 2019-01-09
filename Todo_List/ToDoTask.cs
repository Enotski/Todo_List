using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Todo_List
{
    public class ToDoTask : DependencyObject
    {
        public static readonly DependencyProperty ToDoProperty;
        public static readonly DependencyProperty SettedDateProperty;
        public static readonly DependencyProperty VitalProperty;
        public static readonly DependencyProperty CounterProperty;

        static ToDoTask()
        {
            ToDoProperty = DependencyProperty.Register("ToDo", typeof(string), typeof(ToDoTask));
            SettedDateProperty = DependencyProperty.Register("SettedDate", typeof(DateTime), typeof(ToDoTask));
            VitalProperty = DependencyProperty.Register("Vital", typeof(bool), typeof(ToDoTask));
            CounterProperty = DependencyProperty.Register("Counter", typeof(int), typeof(ToDoTask));
        }

        [Display(Name = "Task")]
        [Required()]
        public string ToDo
        {
            get { return (string)GetValue(ToDoProperty); }
            set { SetValue(ToDoProperty, value); }
        }

        public DateTime SettedDate
        {
            get { return (DateTime)GetValue(SettedDateProperty); }
            set { SetValue(SettedDateProperty, value); }
        }

        public bool Vital
        {
            get { return (bool)GetValue(VitalProperty); }
            set { SetValue(VitalProperty, value); }
        }

        public int Counter
        {
            get { return (int)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }
    }
}