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
using System;

namespace top_project
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private User user;
        public HomeWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            login.Content = user.login;
            if (!string.IsNullOrEmpty(user.avatar))
            {
                avatar.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"../../Resources/Images/{user.avatar}.png")));
            }
            _initData();
        }

        private void _initData()
        {
            var data = from user in Entities.GetContext().User
                       select new
                       {
                           login = user.login,
                           bio = user.bio,
                           userId = user.id
                       };
            dataGrid.ItemsSource = data.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void OpenDitail_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var userWindow = new UserWindow(button.Tag);
            userWindow.Owner = this;
            userWindow.Show();
        }
    }
}
