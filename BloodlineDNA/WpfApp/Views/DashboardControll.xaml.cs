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
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualBasic.ApplicationServices;
using Services;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for DashboardControll.xaml
    /// </summary>
    public partial class DashboardControll : UserControl
    {
        private readonly UserService userService = new();
        private readonly BookingService bookingService = new();
        public int TotalBookings { get; set; }
        public int TotalUsers { get; set; }
        public SeriesCollection PieSeries { get; set; }
        public DashboardControll()
        {
            InitializeComponent();

            var users = userService.GetAllUsers();
            var bookings = bookingService.GetAllBookings();

            TotalUsers = users.Count;
            TotalBookings = bookings.Count;

            var roleCounts = users.GroupBy(u => u.RoleId)
                                  .ToDictionary(g => g.Key, g => g.Count());

            string GetRoleName(int roleId) => roleId switch
            {
                1 => "Khách hàng",
                2 => "Nhân Viên",
                3 => "Quản Lý",
                4 => "Quản Trị Viên"
            };

            PieSeries = new SeriesCollection();
            
            foreach(var entry in roleCounts)
            {
                PieSeries.Add(new PieSeries
                {
                    Title = GetRoleName(entry.Key),
                    Values = new ChartValues<double> { entry.Value },
                    Fill = new SolidColorBrush(GetRoleColor(entry.Key))
                });
            }

            DataContext = this;
        }
        private Color GetRoleColor(int roleId)
        {
            return roleId switch
            {
                1 => Color.FromRgb(0, 255, 255),   // Customer - Cyan
                2 => Color.FromRgb(255, 165, 0),   // Staff - Orange
                3 => Color.FromRgb(144, 238, 144), // Manager - LightGreen
                4 => Color.FromRgb(255, 99, 132),  // Admin - Pink
            };
        }


    }
}
