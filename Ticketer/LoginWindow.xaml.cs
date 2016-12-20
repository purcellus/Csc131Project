﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Intuition;
namespace Ticketer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utility.TextHasNoData(UsernameTextBox))
            {
                MessageBox.Show("No Username!");
                return;
            }
            else if (UserPasswordBox.Password == null || UserPasswordBox.Password.Trim() == "")
            {
                MessageBox.Show("No Password!");
                return;
            }

            bool successs = DatabaseManager.Login(UsernameTextBox.Text.Trim(), UserPasswordBox.Password.Trim());
            if (successs)
            {
                (new MainWindow()).Show();
                this.Close();
            }
            else {
                MessageBox.Show("Invalid Username/password");
            }
        }

        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            (new ForgotPasswordWindow()).Show();
            this.Close();
        }
    }
}
