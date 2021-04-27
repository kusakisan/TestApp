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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowZakaz.xaml
    /// </summary>
    public partial class WindowZakaz : Window
    {
        public WindowZakaz()
        {
            InitializeComponent();
            DataGridZakaz.ItemsSource = HomeTaskEntities.GetContext().Users.ToList();
        }

        private void ButtonNewZakaz_Click(object sender, RoutedEventArgs e)
        {
            RegistrZakaza registrZakaza = new RegistrZakaza();
            registrZakaza.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
