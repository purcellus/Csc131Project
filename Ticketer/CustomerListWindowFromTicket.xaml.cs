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
    /// Interaction logic for CustomerListWindowFromTicket.xaml
    /// </summary>
    public partial class CustomerListWindowFromTicket : Window
    {
        private CreateTicketWindow _previousWindow;
        public CustomerListWindowFromTicket(CreateTicketWindow previousWindow)
        {
            _previousWindow = previousWindow;
            InitializeComponent();
            this.BussinessListView.ItemsSource = CustomerManager.GetCustomers();
        }
        private void GoToEntityButton_Click(object sender, RoutedEventArgs e)
        {
            if (BussinessListView.SelectedItem == null)
            {
                MessageBox.Show("Select a Business!");
            }
            else
            {
                (new EntityListWindow(_previousWindow, (Customer)BussinessListView.SelectedItem)).Show();
                this.Close();
            }
        }

        private void BackToTicketButton_Click(object sender, RoutedEventArgs e)
        {
            _previousWindow.Show();
            this.Close();
        }


        private void AddBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateCustomerWindow(this)).Show();
            this.Hide();
        }

        
    }
}
