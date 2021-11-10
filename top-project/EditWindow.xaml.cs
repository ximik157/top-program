using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace top_project
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private User_posts userPosts;
        public EditWindow(User_posts userPosts)
        {
            InitializeComponent();
            this.userPosts = userPosts;
            DataContext = userPosts;

            if (!string.IsNullOrEmpty(userPosts.attachment))
            {
                image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"image/{System.IO.Path.GetFileName(userPosts.attachment)}.png")));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text.Length > 10)
            {
                Entities.GetContext().SaveChanges();
                ((HomeWindow)this.Owner).UpdateData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Длина текста поста должна быть больше 10 символов");
            }
        }

        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.Copy(openFileDialog.FileName, $"image/{System.IO.Path.GetFileName(openFileDialog.FileName)}", true);
                    userPosts.attachment = openFileDialog.SafeFileName.Replace(".png", "");
                    image.Source = new BitmapImage(new Uri(Path.GetFullPath($"image/{Path.GetFileName(userPosts.attachment)}.png")));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
