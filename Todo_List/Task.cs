using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Todo_List
{
    public class Task : DependencyObject
    {
        public static readonly DependencyProperty ToDoProperty;
        public static readonly DependencyProperty SettedDateProperty;
        public static readonly DependencyProperty VitalProperty;
        public static readonly DependencyProperty CounterProperty;

        static Task()
        {
            ToDoProperty = DependencyProperty.Register("ToDo", typeof(string), typeof(Task));
            SettedDateProperty = DependencyProperty.Register("SettedDate", typeof(DateTime), typeof(Task));
            VitalProperty = DependencyProperty.Register("Vital", typeof(bool), typeof(Task));
            CounterProperty = DependencyProperty.Register("Counter", typeof(int), typeof(Task));
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