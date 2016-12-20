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
    /// Interaction logic for TechListWindow.xaml
    /// </summary>
    public partial class TechListWindow : Window
    {
        private Window _previousWindow;
        public TechListWindow(Window previousWindow)
        {
            InitializeComponent();
            this.TechListView.ItemsSource = TechnicianManager.GetTechnicians();
            _previousWindow = previousWindow;
        }

        private void AddTechButton_Click(object sender, RoutedEventArgs e)
        {
            if (TechListView.SelectedItem == null)
            {
                MessageBox.Show("Select a Technician!");
            }
            else
            {
                // Add to appr window
                if (_previousWindow is CreateTicketWindow)
                {
                    CreateTicketWindow window = (CreateTicketWindow)_previousWindow;
                    window.Technicians.Add(TechListView.SelectedItem as Technician);
                    window.Show();
                    this.Close();
                } else {
                    ViewTicketWindow window = (ViewTicketWindow)_previousWindow;
                    window.Technicians.Add(TechListView.SelectedItem as Technician);
                    window.Show();
                    this.Close();
                }
            }
        }

        private void GoBacktoTicketButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            _previousWindow.Close();
            this.Close();
        }
    }
}
