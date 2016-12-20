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
    /// Interaction logic for EntityListWindow.xaml
    /// </summary>
    public partial class EntityListWindow : Window
    {
        private CreateTicketWindow _ticketWindow;
        private Customer _customer;

        public EntityListWindow(CreateTicketWindow ticketWindow, Customer customer)
        {
            InitializeComponent();
            // Get Entities based on customer
            this.EntityListView.ItemsSource = EntityManager.GetEntities(customer);
            _ticketWindow = ticketWindow;
            _customer = customer;
        }

        private void CreateEntityButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateEntityWindow(this)).Show();
            this.Hide();
        }

        private void BackToTicketButton_Click(object sender, RoutedEventArgs e)
        {
            _ticketWindow.Show();
            this.Close();
        }

        private void SelectEntityButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.EntityListView.SelectedItem == null)
            {
                MessageBox.Show("Select an Entity!");
            }
            else
            {
                _ticketWindow.CustomerEntities.Add(new CustomerEntity{Customer = _customer, Entity = (Entity)EntityListView.SelectedItem});
                _ticketWindow.Show();
                this.Close();
            }
        }
    }


}
