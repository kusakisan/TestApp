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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Users _currentUsers = new Users();

        public EditPage(Users selectedUsers)
        {
            InitializeComponent();          

            if (selectedUsers != null)           
                _currentUsers = selectedUsers;

            DataContext = _currentUsers;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUsers.LastName))
                errors.AppendLine("Укажите имя");

            if (string.IsNullOrWhiteSpace(_currentUsers.FirstName))
                errors.AppendLine("Укажите Фамилию");
           
            if (string.IsNullOrWhiteSpace(_currentUsers.Login))
                errors.AppendLine("Укажите Логин");

            if (string.IsNullOrWhiteSpace(_currentUsers.Password))
                errors.AppendLine("Укажите Пароль");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUsers.id == 0)
            {
                HomeTaskEntities.GetContext().Users.Add(_currentUsers);                
            }

            try
            {
                HomeTaskEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
