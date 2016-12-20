using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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


namespace Ticketer
{
    /// <summary>
    /// Interaction logic for CreateTicketWindow.xaml
    /// </summary>
    public partial class CreateTicketWindow : Window
    {
        public ObservableCollection<Technician> Technicians { get; private set; }
        public ObservableCollection<CustomerEntity> CustomerEntities { get; private set; }
        public ObservableCollection<SupportEvent> SupportEvents { get; private set; } 
        public CreateTicketWindow()
        {
            InitializeComponent();
            this.PriorityComboBox.ItemsSource = Enum.GetValues(typeof(Urgency));

            //Technicians
            Technicians = new ObservableCollection<Technician>();
            TechListViewinTicket.ItemsSource = Technicians;

            // Customer Entities
            CustomerEntities = new ObservableCollection<CustomerEntity>();
            EntityListView.ItemsSource = CustomerEntities;

            // Support Events
            SupportEvents = new ObservableCollection<SupportEvent>();
            SupEventListView.ItemsSource = SupportEvents;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utility.TextHasNoData(this.DueDateTextBox) || Utility.TextHasNoData(this.ProbDescriptionTextBox)) {
                MessageBox.Show("Please Input into all fields");
                return;
            }
            if (PriorityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Select a priority");
                return;
            }

            // Parse the due Date
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            DateTime dueDate;

            if (!DateTime.TryParseExact(DueDateTextBox.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, style, out dueDate))
            {
                MessageBox.Show("Invalid yyyy-MM-dd in due date box");
                return;
            }

            if (CustomerEntities.Count == 0) {
                MessageBox.Show("Please Select a Customer and Entity");
                return;
            }

            // Lets Create the Ticket
            Ticket ticket = new Ticket { 
                TicketDescription = ProbDescriptionTextBox.Text,
                TicketHolder = CustomerEntities[0].Entity,
                TicketRequested = dueDate,
                TicketUrgency = (Urgency)PriorityComboBox.SelectedItem,
                TicketOpenDates = new ObservableCollection<DateTime>(),
                TicketCloseDates = new ObservableCollection<DateTime>(),
                TicketTechnician = Technicians
            };

            ticket.TicketOpenDates.Add(DateTime.Now);
            TicketManager.AddTicket(ticket);

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TechListViewinTicket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void AddTechButton_Click(object sender, RoutedEventArgs e)
        {
            (new TechListWindow(this)).Show();
            this.Hide();
        }

        private void SelectCustandEntButton_Click(object sender, RoutedEventArgs e)
        {
            (new CustomerListWindowFromTicket(this)).Show();
            this.Hide();
        }

        private void SupportEventButton_Click(object sender, RoutedEventArgs e)
        {
            (new SupportEventWindow(this)).Show();
            this.Hide();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();//spawn a main window
            this.Close();//close after submitting ticket to ticket list
        }

    }
}
