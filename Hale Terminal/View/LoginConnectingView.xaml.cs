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
using System.Windows.Threading;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for LoginConnectingView.xaml
    /// </summary>
    public partial class LoginConnectingView : Page
    {
        public LoginConnectingView()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(new LoginView());
            };

            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer2.Start();
            timer2.Tick += (sender, args) =>
            {
                timer2.Stop();
                StatusLabel.Visibility = Visibility.Visible;
            };
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            ContactUsWindow contactUsWindow = new ContactUsWindow();
            contactUsWindow.Show();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
    }
}
