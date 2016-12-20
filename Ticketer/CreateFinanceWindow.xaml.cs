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
    /// Interaction logic for CreateFinanceWindow.xaml
    /// </summary>
    public partial class CreateFinanceWindow : Window
    {
        public Customer Customer { get; set; }
        public CreateFinanceWindow()
        {
            InitializeComponent();
        }

        private void ConfirmOweButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utility.TextHasNoData(this.CompanyBox) || Utility.TextHasNoData(this.HowMuchTextBox) ||
                Utility.TextHasNoData(this.WhyMoneyOwedTextBox) || Customer == null)
            {
                MessageBox.Show("Input all fields");
                return;
            }

            // Create the finance and upload it
            Finance finance = new Finance
            {
                FinanceCustomer = Customer,
                FinanceOwe = HowMuchTextBox.Text,
                FinanceDescription = WhyMoneyOwedTextBox.Text
            };
            FinanceManager.AddFinance(finance);
            (new MainWindow()).Show();
            this.Close();
        }

        private void CancelOweButton_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

        private void SelectCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            (new CUstListFromFinance(this)).Show();
            this.Hide();
        }
    }
}
