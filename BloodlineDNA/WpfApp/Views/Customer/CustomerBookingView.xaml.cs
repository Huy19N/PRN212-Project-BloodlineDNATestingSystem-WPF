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
using BusinessObjects;
using Services;
using Services.Interface;

namespace WpfApp.Views.Customer
{
    /// <summary>
    /// Interaction logic for CustomerBookingView.xaml
    /// </summary>
    public partial class CustomerBookingView : UserControl
    {
        private IBookingService bookingService;
        private int[] comboboxItems = new int[] { 10, 20, 50, 100, 200 };
        public User User { get; set; }
        public CustomerBookingView(User user)
        {
            InitializeComponent();
            bookingService = new BookingService();
            LoadData("", 10, 1);
            User = user;
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

                cmbRecordsPerPage.SelectedIndex = Array.IndexOf(comboboxItems, numberRecordsEachPage);
                txbCurrentPage.Text = bookings.currentPage.ToString();
                txbMaxPage.Text = bookings.maxPage.ToString();
                txbNumberRecords.Text = bookings.numberRecords.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbRecordsPerPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            var bookingForm = new Views.Customer.BookingFormView(User);
            var customerWindow = Window.GetWindow(this) as CustomerWindow;
            if (customerWindow != null)
            {
                customerWindow.MainContent.Content = bookingForm;
            }
        }
    }
}
