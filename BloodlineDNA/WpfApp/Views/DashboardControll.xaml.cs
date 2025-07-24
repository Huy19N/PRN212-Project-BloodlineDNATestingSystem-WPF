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

            TotalUsers = userService.GetAllUsers().Count;
            TotalBookings = bookingService.GetAllBookings().Count;

            PieSeries = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "DNA Test",
                    Values = new ChartValues<double> { 120 },
                    Fill = new SolidColorBrush(Color.FromRgb(0, 255, 255))
                },
                new PieSeries
                {
                    Title = "Paternity",
                    Values = new ChartValues<double> { 80 },
                    Fill = new SolidColorBrush(Color.FromRgb(255, 165, 0))
                },
                new PieSeries
                {
                    Title = "Other",
                    Values = new ChartValues<double> { 50 },
                    Fill = new SolidColorBrush(Color.FromRgb(255, 99, 132))
                }
            };

            DataContext = this;
        }


    }
}
