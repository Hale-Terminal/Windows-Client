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
using Hale_Terminal.Core;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginStartView());
            //Updater updater = new Updater();
            //updater.CheckUpdater();
            //MainFrame.Navigate(new LoginConnectingView());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            TerminalWindow terminalWindow = new TerminalWindow();
            terminalWindow.Show();
        }

        private void ForgotLoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadingButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginStartView());
        }

        private void ConnectingButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginConnectingView());
        }

        private void LoginButton_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginView());
        }
    }
}
