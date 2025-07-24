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
using WpfApp.Views;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        DragMove();
        //    }
        //}

        private void ControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainContent.Content = new DashboardControll();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi xuất dữ liệu bảng thông kê: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainContent.Content = new CustomerControll();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi xuất dữ liệu Khách Hàng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainContent.Content = new BookingControll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất dữ liệu đặt Chỗ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBlog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainContent.Content = new BlogControll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất dữ liệu Blog: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginWindow lw = new LoginWindow();
                lw.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Đăng Xuất: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
