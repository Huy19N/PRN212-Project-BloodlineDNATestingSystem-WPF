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
    /// Interaction logic for AdminCustomerView.xaml
    /// </summary>
    public partial class AdminCustomerView : UserControl
    {
        private readonly IUserService userService = new UserService();
        private int[] comboboxItems = new int[] { 10, 20, 50, 100, 200 };
        public AdminCustomerView()
        {
            InitializeComponent();
            LoadData("", 10, 1);
        }

        public async void LoadData(string key, int numberRecordsEachPage, int currentPage)
        {
            try
            {
                var users = await userService.GetAndSearchUser(key, numberRecordsEachPage, currentPage);
                if (users.Data is List<User> lsUser)
                {
                    lvUser.ItemsSource = lsUser;
                }
                cmbRecordsPerPage.SelectedIndex = 0;
                txbCurrentPage.Text = users.currentPage.ToString();
                txbMaxPage.Text = users.maxPage.ToString();
                txbNumberRecords.Text = users.numberRecords.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
