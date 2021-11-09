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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow(object id)
        {
            InitializeComponent();
            var userId = int.Parse(id.ToString());
            var user = Entities.GetContext().User.Where(u => u.id == userId);
            if (!string.IsNullOrEmpty(user.First().avatar))
            {
                image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"../../Resources/Images/{user.First().avatar}.png")));
            }
            login.Content = user.First().login;
        }
    }
}
