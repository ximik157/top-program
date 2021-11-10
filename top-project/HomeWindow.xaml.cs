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
using Microsoft.Win32;
using System.IO;

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
                avatar.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"image/{System.IO.Path.GetFileName(user.avatar)}.png")));
            }
            UpdateData();
        }

        public void UpdateData()
        {
            Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var data = from post in Entities.GetContext().User_posts
                       where post.owner_id == user.id
                       select new
                       {
                           text = post.text,
                           id = post.id
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
            Button button = sender as Button;
            var userWindow = new PostWindow(button.Tag);
            userWindow.Owner = this;
            userWindow.Show();
        }

        private void OpenEditor_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var userWindow = new EditWindow(Entities.GetContext().User_posts.Where(p => p.id == (long)button.Tag).First());
            userWindow.Owner = this;
            userWindow.Show();
        }

        private void ChangeAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.Copy(openFileDialog.FileName, $"image/{System.IO.Path.GetFileName(openFileDialog.FileName)}", true);
                    user.avatar = openFileDialog.SafeFileName.Replace(".png", "");
                    Entities.GetContext().SaveChanges();
                    Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    avatar.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"image/{System.IO.Path.GetFileName(user.avatar)}.png")));
                }
                catch (Exception) {}
            }
        }
    }
}
