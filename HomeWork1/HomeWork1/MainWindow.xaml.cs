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

namespace HomeWork1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckPassword_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBox.Password;
            TextBoxPassword.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Hidden;
        }

        private void CheckPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = TextBoxPassword.Text;
            PasswordBox.Visibility = Visibility.Visible;
            TextBoxPassword.Visibility = Visibility.Hidden;
        }

     

        //public void Proverka()
        //{
        //    if (TextBoxLogin.Text == "login1" && (PasswordBox.Password == "tuptup" || TextBoxPassword.Text == "tuptup"))
        //    {
        //        var Zakaz = new Zakaz();

        //    }           
        //    else
        //    {
        //        MessageBox.Show("Неверно введены данные");
        //    }
        //}

        private void ButtonAuthorizited_Click(object sender, RoutedEventArgs e)
        {
            Zakaz zakaz = new Zakaz();
            zakaz.Show();
        }
    }
}
