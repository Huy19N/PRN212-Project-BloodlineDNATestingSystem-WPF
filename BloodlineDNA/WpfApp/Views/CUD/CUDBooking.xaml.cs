using BusinessObjects;
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

namespace WpfApp.Views.CUD
{
    /// <summary>
    /// Interaction logic for CUDBooking.xaml
    /// </summary>
    public partial class CUDBooking : UserControl
    {
        private int bookingId;
        private IAdminService service = new AdminService();
        private string[] lsGender = new string[] { "Male", "Female", "Other" };
        private Patient patient1;
        private Patient patient2; 
        public CUDBooking(int BookingId)
        {
            InitializeComponent();
            bookingId = BookingId;
        }

        public void LoadData(int BookingId)
        {

            var booking = service.GetBookingById(BookingId);
            if (booking != null)
            {
                patient1 = booking.Patients?.ToList()[0] ?? new Patient();
                patient2 = booking.Patients?.ToList().Count > 1 ? booking.Patients?.ToList()[1] ?? new Patient() : new Patient();

                var servicePrice = service.GetAllAvailableServicePrices();
                var duration = servicePrice?.Select(sp => sp.Duration).Distinct().ToList();
                var sv = servicePrice?.Select(sp => sp.Service).Distinct().ToList();

                txtMoney.Text = booking.ServicePrice?.Price.ToString("C");
                
                cmbService.ItemsSource = sv;
                cmbService.DisplayMemberPath = "ServiceType";
                cmbService.SelectedValuePath = "ServiceId";
                cmbService.SelectedValue = booking.ServicePrice?.ServiceId;

                cmbDuration.ItemsSource = duration;
                cmbDuration.DisplayMemberPath = "DurationName";
                cmbDuration.SelectedValuePath = "DurationId";
                cmbDuration.SelectedValue = booking.ServicePrice?.DurationId;


                txtPName1.Text = patient1.FullName;
                txtPName2.Text = patient2.FullName;

                txtPDate1.Text = patient1.BirthDate.ToString("dd/MM/yyyy");
                txtPDate2.Text = patient2.BirthDate.ToString("dd/MM/yyyy");

                txtPGender1.Text = patient1.Gender;
                txtPGender2.Text = patient2.Gender;

                cmbPSample1.ItemsSource = cmbPSample2.ItemsSource = service.GetAllSamples();
                cmbPSample1.DisplayMemberPath = cmbPSample2.DisplayMemberPath = "SampleName";
                cmbPSample1.SelectedItem = cmbPSample2.SelectedValuePath = "SampleId";
                cmbPSample1.SelectedValue = patient1.SampleId;
                cmbPSample2.SelectedValue = patient2.SampleId;

                txtPID1.Text = patient1.IdentifyId;
                txtPID2.Text = patient2.IdentifyId;

                txtBookingDate.Text = booking.Date.ToString();
                cmbStatus.ItemsSource = service.GetAllStatuses();

                cmbCollectionMethod.ItemsSource = service.GetAllCollectionMethods();
                cmbCollectionMethod.DisplayMemberPath = "MethodName";
                cmbCollectionMethod.SelectedValuePath = "MethodId";
                cmbCollectionMethod.SelectedValue = booking.MethodId;

                txtResult.Text = booking.TestResult?.ResultSummary;

            }
            else
            {
                MessageBox.Show("Booking not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
