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
            var postId = int.Parse(id.ToString());
            var post = Entities.GetContext().User_posts.Where(p => p.id == postId);
            if (!string.IsNullOrEmpty(post.First().attachment))
            {
                image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"../../Resources/Images/{post.First().attachment}.png")));
            }
            text.Text = post.First().text;
        }
    }
}
