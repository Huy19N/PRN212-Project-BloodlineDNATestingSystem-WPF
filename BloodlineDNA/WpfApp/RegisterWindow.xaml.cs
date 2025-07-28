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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserService userService = new();
        bool Load = false;
        public RegisterWindow()
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

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Load = false;
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Password) ||
                    string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtIdentify.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if(!int.TryParse(txtIdentify.Text.Trim(), out int identifyId) || identifyId <= 0)
                {
                    MessageBox.Show("Số CMND/CCCD không hợp lệ!", "Lỗi Đăng Ký", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (txtPassword.Password != txtConfirmPassword.Password)
                {
                    MessageBox.Show("Mật Khẩu và Xác Nhận Mật Khẩu Không Trùng Khớp!", "Lỗi Đăng Ký", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var user = new User
                {
                    Email = txtUserName.Text.Trim(),
                    Password = txtPassword.Password.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    IdentifyId = txtIdentify.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    RoleId = 1
                };

                userService.Register(user);
                MessageBox.Show("Đăng Ký Thành Công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
                Load = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Không thể Đăng Ký", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                LoginWindow lw = new LoginWindow();
                lw.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể quay lại đăng nhập!");
            }
        }
    }
}
