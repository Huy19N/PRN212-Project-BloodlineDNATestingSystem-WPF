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
        private IAdminService service;
        private string[] lsGender = new string[] { "Male", "Female", "Other" };
        private Patient patient1 = new Patient();
        private Patient patient2 = new Patient();
        private bool firstRun = true;
        private Booking? booking = new Booking();
        public CUDBooking(int BookingId)
        {
            InitializeComponent();
            bookingId = BookingId;
            service = new AdminService();
            LoadData(bookingId);
        }

        public void LoadData(int BookingId)
        {
            try
            {
                booking = service.GetBookingById(bookingId);
                if (booking != null)
                {
                    patient1 = booking.Patients?.ToList().Count > 0 ? booking.Patients?.ToList()[0] ?? new Patient() : new Patient();
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
                    cmbPSample1.SelectedValuePath = cmbPSample2.SelectedValuePath = "SampleId";
                    cmbPSample1.SelectedValue = patient1.SampleId;
                    cmbPSample2.SelectedValue = patient2.SampleId;

                    txtPID1.Text = patient1.IdentifyId;
                    txtPID2.Text = patient2.IdentifyId;

                    txtBookingDate.Text = booking.Date.ToString();
                    cmbStatus.ItemsSource = service.GetAllStatuses();
                    cmbStatus.DisplayMemberPath = "StatusName";
                    cmbStatus.SelectedValuePath = "StatusId";
                    cmbStatus.SelectedValue = booking.StatusId;

                    cmbCollectionMethod.ItemsSource = service.GetAllCollectionMethods();
                    cmbCollectionMethod.DisplayMemberPath = "MethodName";
                    cmbCollectionMethod.SelectedValuePath = "MethodId";
                    cmbCollectionMethod.SelectedValue = booking.MethodId;

                    txtResult.Text = booking.TestResult?.ResultSummary;
                    firstRun = false;
                }
                else
                {
                    MessageBox.Show("Booking not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.GetWindow(this)?.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Window.GetWindow(this)?.Close();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (booking != null)
                {
                    patient1.FullName = txtPName1.Text;
                    patient1.BirthDate = DateTime.TryParse(txtPDate1.Text, out DateTime birthDate1) ? DateOnly.FromDateTime(birthDate1) : DateOnly.FromDateTime(DateTime.Now);
                    patient1.IdentifyId = txtPID1.Text;
                    patient1.BookingId = bookingId;
                    patient1.Gender = txtPGender1.Text;
                    if (int.TryParse(cmbPSample1.SelectedValue?.ToString(), out int sampleId1))
                    {
                        patient1.SampleId = sampleId1;
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid sample for Patient 1.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    patient2.FullName = txtPName2.Text;
                    patient2.BirthDate = DateTime.TryParse(txtPDate2.Text, out DateTime birthDate2) ? DateOnly.FromDateTime(birthDate2) : DateOnly.FromDateTime(DateTime.Now);
                    patient2.IdentifyId = txtPID2.Text;
                    patient2.BookingId = bookingId;
                    patient2.Gender = txtPGender2.Text;
                    if ((int.TryParse(cmbPSample2.SelectedValue?.ToString(), out int sampleId2)))
                    {
                        patient2.SampleId = sampleId2;
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid sample for Patient 2.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    booking.Patients.Clear();
                    booking.Patients.Add(patient1);
                    booking.Patients.Add(patient2);
                    booking.ServicePrice = service.GetServicePriceByServiceAndDuration(
                    cmbService.SelectedValue is int serviceId ? serviceId : 0,
                    cmbDuration.SelectedValue is int durationId ? durationId : 0
                    );
                    if (booking.ServicePrice == null)
                    {
                        MessageBox.Show("Service price not found for the selected service and duration.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    booking.MethodId = cmbCollectionMethod.SelectedValue is int methodId ? methodId : (int?)null;
                    booking.StatusId = cmbStatus.SelectedValue is int statusId ? statusId : (int?)null;
                    if (booking.TestResult == null)
                    {
                        booking.TestResult = new TestResult
                        {
                            BookingId = bookingId,
                            ResultSummary = txtResult.Text,
                            Date = DateTime.Now
                        };
                    }
                    else
                    {
                        booking.TestResult.ResultSummary = txtResult.Text;
                        booking.TestResult.Date = DateTime.Now;
                    }
                    if (service.UpdateBookingWithPatients(booking))
                    {
                        MessageBox.Show("Booking Update Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.GetWindow(this)?.Close();
                        return;
                    }
                    MessageBox.Show("Booking Unsuccess", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Window.GetWindow(this)?.Close();

                }
                else
                {
                    MessageBox.Show("Booking not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void btnDeletet_Click(object sender, RoutedEventArgs e)
        {
            var isConfirmed = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (isConfirmed == MessageBoxResult.Yes)
            {
                try
                {
                    if (service.deleteBookingById(bookingId))
                    {
                        
                        
                        MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.GetWindow(this)?.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete booking.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void cmbDuration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!firstRun && int.TryParse(cmbDuration.SelectedValue.ToString(),out int durationid) && int.TryParse(cmbService.SelectedValue.ToString(), out int serviceid))
            {
                var servicePrice = service.GetServicePriceByServiceAndDuration(serviceid, durationid);
                txtMoney.Text = servicePrice?.Price.ToString("C");
                if (servicePrice == null)
                {
                    MessageBox.Show("Service price not found for the selected service and duration.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void cmbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!firstRun && int.TryParse(cmbDuration.SelectedValue.ToString(), out int durationid) && int.TryParse(cmbService.SelectedValue.ToString(), out int serviceid))
            {

                var servicePrice = service.GetServicePriceByServiceAndDuration(serviceid, durationid);
                txtMoney.Text = servicePrice?.Price.ToString("C");
                if (servicePrice == null)
                {
                    MessageBox.Show("Service price not found for the selected service and duration.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
