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
    /// Interaction logic for CreateTechWindow.xaml
    /// </summary>
    public partial class CreateTechWindow : Window
    {
        public CreateTechWindow()
        {
            InitializeComponent();
        }

        private void NewTechButton_Click(object sender, RoutedEventArgs e)
        {
            // Sanity Check
            if (Utility.TextHasNoData(TechAddressTextBox))
            {
                MessageBox.Show("Input Address");
                return;
            }
            else if (Utility.TextHasNoData(TechEmailTextBox))
            {
                MessageBox.Show("Input Email");
                return;
            }
            else if (Utility.TextHasNoData(TechNameTextBox))
            {
                MessageBox.Show("Input Name");
                return;
            }
            else if (TechPasswordPasswordBox.Password == null || TechPasswordPasswordBox.Password.Trim() == "")
            {
                MessageBox.Show("Input Password");
                return;
            }
            else if (Utility.TextHasNoData(TechUsernameTextBox))
            {
                MessageBox.Show("Input Username");
                return;
            }

            // Create tech and add him
            Technician technician = new Technician
            {
                TechnicianUsername = TechUsernameTextBox.Text,
                TechnicianAddress = TechAddressTextBox.Text,
                TechnicianEmail = TechEmailTextBox.Text,
                TechnicianName = TechNameTextBox.Text
            };

            TechnicianManager.AddTechnician(technician, TechPasswordPasswordBox.Password);
            
            
            (new MainWindow()).Show();
            this.Close();
        }

        private void CancelTechButton_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

    }
}
