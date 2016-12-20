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
using System.Collections.ObjectModel;

namespace Ticketer
{
    /// <summary>
    /// Interaction logic for ViewTicketWindow.xaml
    /// </summary>
    public partial class ViewTicketWindow : Window
    {
        private Ticket _ticket;
        public ObservableCollection<Technician> Technicians { get; private set; }
        public ObservableCollection<CustomerEntity> CustomerEntities { get; private set; }
        public ObservableCollection<SupportEvent> SupportEvents { get; private set; } 
        public ViewTicketWindow(Ticket ticket)
        {
            InitializeComponent();
            _ticket = ticket;

            this.PriorityComboBoxinView.ItemsSource = Enum.GetValues(typeof(Urgency));
            this.PriorityComboBoxinView.SelectedItem = _ticket.TicketUrgency;
            
            // Setup Data
            Technicians = _ticket.TicketTechnician;
            this.TechListViewinTicketViewinView.ItemsSource = Technicians;

            SupportEvents = SupportEventManager.GetSupportEvents(_ticket);
            this.SupEventListView.ItemsSource = SupportEvents;

            CustomerEntities = new ObservableCollection<CustomerEntity>() { 
                new CustomerEntity {
                    Customer = _ticket.TicketHolder.EntityOwner,
                    Entity = _ticket.TicketHolder
                }
            };
            this.EntityListViewinView.ItemsSource = CustomerEntities;
        }

        private void SupportEventButton_Click(object sender, RoutedEventArgs e)
        {
            (new SupportEventWindow(this)).Show();
            this.Hide();
        }

        private void AddTechButtoninView_Click(object sender, RoutedEventArgs e)
        {
            (new TechListWindow(this)).Show();
            this.Hide();
        }

        private void StartButtoninView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopButtoninView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReopenButton_Click(object sender, RoutedEventArgs e)
        {
            _ticket.TicketUrgency = (Urgency)this.PriorityComboBoxinView.SelectedItem;
            TicketManager.SaveTicket(_ticket);
            (new MainWindow()).Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _ticket.TicketUrgency = Urgency.None;
            _ticket.TicketCloseDates.Add(DateTime.Now);
            TicketManager.SaveTicket(_ticket);
            (new MainWindow()).Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _ticket.TicketUrgency = (Urgency)this.PriorityComboBoxinView.SelectedItem;
            TicketManager.SaveTicket(_ticket);
            (new MainWindow()).Show();
            this.Close();
        }
    }
}
