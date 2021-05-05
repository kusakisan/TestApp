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

namespace practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string nameLogin; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string pass = TextBoxPass.Text.Trim();
            string password = Password.Password.Trim();
            string login = TextBoxLogin.Text.Trim();

            Users logUsers = null;
            using (HomeTaskEntities db = new HomeTaskEntities())
            {
                logUsers = db.Users.Where(data => data.Login == login && (data.Password == password || data.Password == pass)).FirstOrDefault();
            }

            if (logUsers != null)
            {
                Window2 window2 = new Window2();
                window2.Show();
                Hide();
            }

            else
            {
                MessageBox.Show("Проверьте ввод данных", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CheckBoxPass_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPass.Text = Password.Password;
            Password.Visibility = Visibility.Hidden;
            TextBoxPass.Visibility = Visibility.Visible;
            
        }

        private void CheckBoxPass_Unchecked(object sender, RoutedEventArgs e)
        {
            Password.Password = TextBoxPass.Text;
            Password.Visibility = Visibility.Visible;
            TextBoxPass.Visibility = Visibility.Hidden;
            
        }
    }
}
