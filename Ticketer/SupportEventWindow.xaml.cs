using System;
using System.Collections.Generic;
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
    /// Interaction logic for SupportEventWindow.xaml
    /// </summary>
    public partial class SupportEventWindow : Window
    {
        private Window _previousWindow;
        public SupportEventWindow(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void BackToCreateTicketButton_Click(object sender, RoutedEventArgs e)
        {//do it so that it makes a new window based on where it's from (createticket or viewticket
            _previousWindow.Show();
            this.Close();
        }

        private void AddSupEventButton_Click(object sender, RoutedEventArgs e)
        {
            // Check data
            if (Utility.TextHasNoData(this.SupNameTextBox) || Utility.TextHasNoData(this.SupDescTextBox) ||
                Utility.TextHasNoData(this.TimeSupClose) || Utility.TextHasNoData(this.TimeSupOpen))
            {
                MessageBox.Show("Please fill all of the fields");
                return;
            }

            // Get time time if we can
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            string todayDate = DateTime.Now.ToString("yyy-MM-dd");
            DateTime closeTime;
            DateTime openTime;

            if (
                !DateTime.TryParseExact(todayDate + " " + TimeSupClose.Text, "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture, style, out closeTime))
            {
                MessageBox.Show("Invalid HH:mm in CloseTime");
                return;
            }

            if (
                !DateTime.TryParseExact(todayDate + " " + TimeSupOpen.Text, "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture, style, out openTime))
            {
                MessageBox.Show("Invalid HH:mm in OpenTime");
                return;
            }

            SupportEvent supportEvent = new SupportEvent
            {
                SupportEventDescription = SupDescTextBox.Text,
                SupportEventName = SupNameTextBox.Text,
                SupportEventStart = openTime,
                SupportEventStop = closeTime
            };

            // Add it to the appropiate window

            if (_previousWindow is CreateTicketWindow)
            {
                CreateTicketWindow ticketWindow = (CreateTicketWindow) _previousWindow;
                ticketWindow.SupportEvents.Add(supportEvent);
                ticketWindow.Show();
                this.Close();
            }
            else
            {
                ViewTicketWindow ticketWindow = (ViewTicketWindow) _previousWindow;
                ticketWindow.SupportEvents.Add(supportEvent);
                ticketWindow.Show();
                this.Close();
            }
        }
    }
}
