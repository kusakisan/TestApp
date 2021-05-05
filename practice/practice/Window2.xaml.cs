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
using System.Windows.Shapes;

namespace practice
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            Manager.MainFrame = MainFrame;
            
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
           

        }

    

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
