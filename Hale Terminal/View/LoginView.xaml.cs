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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            UsernameTextBox.Focus();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            ContactUsWindow contactUsWindow = new ContactUsWindow();
            contactUsWindow.Show();
        }

        private void ForgotLoginButton_Click(object sender, RoutedEventArgs e)
        {
            ForgotLoginWindow forgotLoginWindow = new ForgotLoginWindow();
            forgotLoginWindow.Show();
        }

        private void UsernameTextBox_Click(object sender, MouseButtonEventArgs e)
        {
            UsernameTextBox.BorderBrush = Brushes.Transparent;
            PasswordTextBox.BorderBrush = Brushes.Transparent;
        }

        private void PasswordBox_Click(object sender, MouseButtonEventArgs e)
        {
            UsernameTextBox.BorderBrush = Brushes.Transparent;
            PasswordTextBox.BorderBrush = Brushes.Transparent;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.IsEnabled = false;
            PasswordTextBox.IsEnabled = false;
            LoginButton.IsEnabled = false;
        }
    }
}
