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
using Logic;
using Intuition;


namespace Ticketer
{
    /// <summary>
    /// Interaction logic for CreateCustomerWindow.xaml
    /// </summary>
    public partial class CreateCustomerWindow : Window
    {
        private Window _previousWindow;

        public CreateCustomerWindow(Window previousWindow)
        {
            _previousWindow = previousWindow;
            InitializeComponent();
        }

        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            // Sanity Check
            if (CustomerName.Text == null || CustomerName.Text.Trim() == "") {
                MessageBox.Show("Input a name!");
                return;
            }
            else if (CustomerEmailTextBox.Text == null || CustomerEmailTextBox.Text.Trim() == "") {
                MessageBox.Show("Input an Email!");
                return;
            }
            else if (CustomerAddressTextBox.Text == null || CustomerAddressTextBox.Text.Trim() == null) {
                MessageBox.Show("Input an Address!");
                return;
            }

            // Create the customer and add it
            Customer customer = new Customer { 
                CustomerAddress = CustomerAddressTextBox.Text,
                CustomerDescription = CustomerDescriptionTextBox.Text ?? "",
                CustomerEmail = CustomerEmailTextBox.Text,
                CustomerName = CustomerName.Text,
                CustomerWebsite = CustomerWebsiteTextBox.Text ?? ""
            };

            CustomerManager.AddCustomer(customer);

            _previousWindow.Show();



            this.Close();
        }

        private void BacktoBusinessesScreen_Click(object sender, RoutedEventArgs e)
        {
            
            _previousWindow.Show();
            this.Close();
        }
    }
}
