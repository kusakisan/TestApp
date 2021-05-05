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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

      
        public MainPage()
        {
            InitializeComponent();
                           



            //DGridTovar.ItemsSource = HomeTaskEntities.GetContext().Users.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditPage((sender as Button).DataContext as Users));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditPage(null));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridTovar.SelectedItems.Cast<Users>().ToList();

            if (MessageBox.Show($"Вы уверены, что хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);
            {

                try
                {
                    HomeTaskEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    HomeTaskEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridTovar.ItemsSource = HomeTaskEntities.GetContext().Users.ToList();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
              
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HomeTaskEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridTovar.ItemsSource = HomeTaskEntities.GetContext().Users.ToList();
            }
        }

        //private void MainFrame_ContentRendered(object sender, EventArgs e)
        //{
        //    if (MainFrame.CanGoBack)
        //    {
        //        ButtonBack.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        ButtonBack.Visibility = Visibility.Hidden;
        //    }
        //}
    }
}
