using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace top_project
{
    /// <summary>
    /// Логика взаимодействия для PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        public PostWindow(object id)
        {
            InitializeComponent();
            var post = Entities.GetContext().User_posts.Where(p => p.id == (long)id);
            if (!string.IsNullOrEmpty(post.First().attachment))
            {
                image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"image/{System.IO.Path.GetFileName(post.First().attachment)}.png")));
            }
            text.Text = post.First().text;
        }
    }
}
