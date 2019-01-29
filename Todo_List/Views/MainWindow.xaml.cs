using System;
using System.Linq;
using System.Windows;
using Todo_List.ViewModels;
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TodoViewModel();
        }
    }
}
