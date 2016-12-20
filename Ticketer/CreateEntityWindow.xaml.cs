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
    /// Interaction logic for CreateEntityWindow.xaml
    /// </summary>
    public partial class CreateEntityWindow : Window
    {
        public Customer SelectedCustomer { get; set; }
        private Window _previousWindow;
        public CreateEntityWindow(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void CreateEntityButton_Click(object sender, RoutedEventArgs e)
        {
            // Sanity Check
            if (EntityNameTextBox.Text == null || EntityNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Input Name!");
                return;
            }
            else if (EntityOwnerTextBox.Text == null || EntityNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Input Owner!");
                return;
            }
            else if (EntityDescTextBox.Text == null || EntityNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Input Description!");
                return;
            }

            // Get the customer and create the entity and add it
            Customer customer = CustomerManager.GetCustomer(EntityOwnerTextBox.Text);

            Entity entity = new Entity
            {
                EntityDescription = EntityDescTextBox.Text,
                EntityName = EntityNameTextBox.Text,
                EntityOwner = customer
            };

            EntityManager.AddEntity(entity);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            _previousWindow.Show();
            this.Close();
        }

        private void EntityOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            (new CustlistFromEntityWindow(this)).Show();
            this.Hide();
        }
    }
}
