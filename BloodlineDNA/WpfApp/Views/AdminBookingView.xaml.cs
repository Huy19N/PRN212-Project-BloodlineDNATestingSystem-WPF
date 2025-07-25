using BusinessObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;
using Services.Interface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for AdminBookingView.xaml
    /// </summary>
    public partial class AdminBookingView : UserControl
    {
        private IBookingService bookingService;
        public AdminBookingView()
        {
            InitializeComponent();
            bookingService = new BookingService();
            LoadData("", 10, 1);
        }

        public async void LoadData(string key, int numberRecordsEachPage, int currentPage)
        {
            try
            {
                    var bookings = await bookingService.GetAndSearchBooking(key, numberRecordsEachPage, currentPage);
                    if (bookings.Data is List<Booking> lsBooking)
                    {
                    lvBooking.ItemsSource = lsBooking;
                    }
                    cmbRecordsPerPage.SelectedIndex = numberRecordsEachPage;
                    txbCurrentPage.Text = bookings.currentPage.ToString();
                    txbMaxPage.Text = bookings.maxPage.ToString();
                    txbNumberRecords.Text = bookings.numberRecords.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnAddResult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbRecordsPerPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
