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
        private bool isMaximized = false;
        private Rect previousRect;
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (!isMaximized)
            {
                previousRect = new Rect(Left, Top, Width, Height);
                var workArea = SystemParameters.WorkArea;
                Left = workArea.Left;
                Top = workArea.Top;
                Width = workArea.Width;
                Height = workArea.Height;
                isMaximized = true;
            }
            else
            {
                Left = previousRect.Left;
                Top = previousRect.Top;
                Width = previousRect.Width;
                Height = previousRect.Height;
                isMaximized = false;
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

        private void btnBooking_Checked(object sender, RoutedEventArgs e)
        {
            var view = new Views.AdminBookingView();
            MainContent.Content = view;
        }

        private void btnCustomer_Checked(object sender, RoutedEventArgs e)
        {
            var view = new Views.AdminCustomerView();
            MainContent.Content = view;
        }
    }
}
