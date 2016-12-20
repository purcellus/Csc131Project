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
using Intuition;
using Logic;

namespace Ticketer
{
    /// <summary>
    /// Interaction logic for CUstListFromFinance.xaml
    /// </summary>
    public partial class CUstListFromFinance : Window
    {
        private CreateFinanceWindow _previousWindow;

        public CUstListFromFinance(CreateFinanceWindow previousWindow)
        {
            _previousWindow = previousWindow;
            InitializeComponent();
            BussinessListView.ItemsSource = CustomerManager.GetCustomers();
        }

        private void AddBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            if (BussinessListView.SelectedItem == null)
            {
                MessageBox.Show("Select a business!");
            }
            else
            {
                _previousWindow.Customer = (Customer) BussinessListView.SelectedItem;
                _previousWindow.CompanyBox.Text = _previousWindow.Customer.CustomerName;
                _previousWindow.Show();
                this.Close();    
            }
            
        }

        private void BackToFinanceButton_Click(object sender, RoutedEventArgs e)
        {
            _previousWindow.Show();
            this.Close();
        }

        private void CreateBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateCustomerWindow(this)).Show();
            this.Hide();
        }
    }
}
