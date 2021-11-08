﻿using System.Linq;
using System.Windows;

namespace top_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_auth_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTextBox.Text) && !string.IsNullOrEmpty(passwordBox.Password))
            {
                var user = Entities.GetContext().user.Where(p => p.login == loginTextBox.Text && p.password == passwordBox.Password);
                if (user.Count() == 1)
                {
                    MessageBox.Show($"Добро пожаловать {user.First().login}");
                }
                else
                {
                    MessageBox.Show("Неверный логин и пароль");
                }
            }
        }
    }
}
