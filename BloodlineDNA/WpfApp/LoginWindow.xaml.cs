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
using BusinessObjects;
using Services.Interface;
using Services;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService userService = new();
        public LoginWindow()
        {
                InitializeComponent();
            
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                return;
            }
            WindowState = WindowState.Maximized;
            
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = userService.Login(txtUserName.Text, txtPassword.Password);

            if (user == null)
            {
                MessageBox.Show("Tài Khoản này Chưa Tồn Tại!", "Đăng Nhập Thất Bại", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(user.RoleId != 1)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
            else if(user.RoleId == 1)
            {
                CustomerWindow cw = new CustomerWindow();
                cw.Show();
                this.Close();
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
            this.Close();
        }
    }
}
