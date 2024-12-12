using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.ViewModel;


namespace ToDoList
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vs = new MainWindowViewModel();
            DataContext = vs;
        }

        private void AddItem( object sender, RoutedEventArgs e)
        {

        }
        private void DeleteItem(object sender, RoutedEventArgs e)
        {

        }
        private void DoneItem(object sender, RoutedEventArgs e)
        { 

        }
        private void UndoneItem(object sender, RoutedEventArgs e)
        { 

        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {

        }

    }
}
