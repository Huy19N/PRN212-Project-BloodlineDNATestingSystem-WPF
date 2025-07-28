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
using Services;
using Services.Interface;
using WpfApp.Views;

namespace WpfApp.Views.Customer
{
    /// <summary>
    /// Interaction logic for BookingFormView.xaml
    /// </summary>
    public partial class BookingFormView : UserControl
    {
        private readonly BookingService _bookingService;
        private readonly PatientService _patientService;
        private readonly ServicePriceService _servicePriceService;
        private readonly User _currentUserId;
        public BookingFormView(User userId)
        {
            InitializeComponent();

            
            _currentUserId = userId;

            _bookingService = new BookingService();
            _patientService = new PatientService();
            _servicePriceService = new ServicePriceService();

            LoadServicePrice();
        }

        private void LoadServicePrice()
        {
            try
            {
                var servicePrices = _servicePriceService.GetAllServicePrices();
                cbServicePrice.ItemsSource = servicePrices;
                cbServicePrice.DisplayMemberPath = "Price"; 
                cbServicePrice.SelectedValuePath = "ServicePriceId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu cơ bản
                if (cbServicePrice.SelectedValue == null || !dpAppointmentDate.SelectedDate.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ và ngày hẹn.");
                    return;
                }
                if (!dpPerson1Birth.SelectedDate.HasValue || !dpPerson2Birth.SelectedDate.HasValue)
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh cho cả hai người.");
                    return;
                }

                // Tạo Booking
                var booking = new Booking
                {
                    UserId = _currentUserId.UserId,
                    ServicePriceId = (int)cbServicePrice.SelectedValue,
                    AppointmentTime = dpAppointmentDate.SelectedDate.Value,
                    StatusId = 1,
                    Date = DateTime.Now
                };
                _bookingService.AddBooking(booking);

                // Tạo Patient 1
                var patient1 = new Patient
                {
                    BookingId = booking.BookingId,
                    FullName = txtPerson1Name.Text,
                    Gender = txtGender1.Text,
                    BirthDate = DateOnly.FromDateTime(dpPerson1Birth.SelectedDate.Value),
                    IdentifyId = txtPerson1ID.Text
                };
                _patientService.AddPatient(patient1);

                // Tạo Patient 2
                var patient2 = new Patient
                {
                    BookingId = booking.BookingId,
                    FullName = txtPerson2Name.Text,
                    Gender = txtGender2.Text,
                    BirthDate = DateOnly.FromDateTime(dpPerson2Birth.SelectedDate.Value),
                    IdentifyId = txtPerson2ID.Text
                };
                _patientService.AddPatient(patient2);

                MessageBox.Show("Đặt lịch thành công!");

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo booking: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            cbServicePrice.SelectedIndex = -1;
            dpAppointmentDate.SelectedDate = null;

            txtPerson1Name.Clear();
            txtGender1.Clear();
            dpPerson1Birth.SelectedDate = null;
            txtPerson1ID.Clear();

            txtPerson2Name.Clear();
            txtGender2.Clear();
            dpPerson2Birth.SelectedDate = null;
            txtPerson2ID.Clear();
        }
    }
}
