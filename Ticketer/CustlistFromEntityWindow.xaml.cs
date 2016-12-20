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
    /// Interaction logic for CustlistFromEntityWindow.xaml
    /// </summary>
    public partial class CustlistFromEntityWindow : Window
    {
        private readonly CreateEntityWindow _previousWindow;

        public CustlistFromEntityWindow(CreateEntityWindow previousWindow)
        {
            _previousWindow = previousWindow;
            InitializeComponent();
            var customers = CustomerManager.GetCustomers();
            BussinessListView.ItemsSource = customers;
        }

        private void BackToEntityButton_Click(object sender, RoutedEventArgs e)
        {
            _previousWindow.Show();
            this.Close();
        }

        private void AddBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.BussinessListView.SelectedItem == null)
            {
                MessageBox.Show("Select a Business!");
            }
            else
            {
                _previousWindow.SelectedCustomer = (Customer) BussinessListView.SelectedItem;
                _previousWindow.Show();
                _previousWindow.EntityOwnerTextBox.Text = _previousWindow.SelectedCustomer.CustomerName;
                this.Close();
            }
        }

    }
}
