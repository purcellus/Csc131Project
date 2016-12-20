using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Ticket> _tickets;
        private ObservableCollection<Finance> _finances;
        private ObservableCollection<Customer> _businesses;
        private ObservableCollection<Technician> _techs;
        public MainWindow()
        {
            InitializeComponent();

            // Set Sources
            _tickets = TicketManager.GetTickets();
            TicketListView.ItemsSource = _tickets;

            _finances = FinanceManager.GetFinances();
            FinancesListView.ItemsSource = _finances;

            _businesses = CustomerManager.GetCustomers();
            BussinessListView.ItemsSource = _businesses;

            _techs = TechnicianManager.GetTechnicians();
            TechListView.ItemsSource = _techs;
        }
        private void CreateTicketButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateTicketWindow()).Show();
            this.Close();
        }

        private void TicketListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TicketListView.SelectedItem != null)
            {
                Ticket ticket = TicketListView.SelectedItem as Ticket;
                string info = string.Format("Ticket Description: {0}\nTicket Customer: {1}\nTicket Urgency: {2}\nTicket Customer Address: {3}", ticket.TicketDescription, ticket.TicketHolder.EntityOwner.CustomerName, ticket.TicketUrgency, ticket.TicketHolder.EntityOwner.CustomerAddress);
                MessageBox.Show(info);
            }

        }

        private void AddTechButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateTechWindow()).Show();
            this.Close();
        }

        private void AddBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateCustomerWindow(this)).Show();
            this.Hide();
        }

        private void BussinessListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFinanceButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateFinanceWindow()).Show();
            this.Close();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
