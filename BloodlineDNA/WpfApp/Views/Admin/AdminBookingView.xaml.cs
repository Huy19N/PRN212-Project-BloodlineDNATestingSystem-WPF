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
        private IAdminService service = new AdminService();
        private int[] comboboxItems = new int[] { 10, 20, 50, 100, 200 };
        public AdminBookingView()
        {
            InitializeComponent();
            
            LoadData("", 10, 1);
        }

        public async void LoadData(string key, int numberRecordsEachPage, int currentPage)
        {
            try
            {
                var bookings = await service.GetAndSearchBooking(key, numberRecordsEachPage, currentPage);
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


        private void btnAddResult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], 1);
        }

        private void cmbRecordsPerPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentPage = int.TryParse(txbCurrentPage?.Text, out int tempPage) ? tempPage : 1;
            LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], currentPage);
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn && btn.CommandParameter is Booking booking)
            {
                MessageBox.Show($"Edit booking with ID: {booking.BookingId}", "Edit Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid booking data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txbCurrentPage.Text,out int currentPage))
            {
                currentPage--;
                LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], currentPage<=0? 1: currentPage);
            }
            else
            {
                LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], 1);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txbCurrentPage.Text, out int currentPage))
            {
                currentPage++;
                if(int.TryParse(txbMaxPage.Text, out int maxPage))
                {
                    LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], currentPage >= maxPage ? maxPage : currentPage);
                    return;
                }
            }
            LoadData(txtSearch.Text, comboboxItems[cmbRecordsPerPage.SelectedIndex], 1);
        }
    }
}
