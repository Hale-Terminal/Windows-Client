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
using Hale_Terminal.Model;
using Hale_Terminal.Sound;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Reflection;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        HLog hLog = new HLog();
        public LoginWindow()
        {
            InitializeComponent();
            hLog.Debug("Loaded Login Window");
            UsernameTextBox.Focus();

            var SerialNumber = Settings.Default.SerialNumber;
            if (SerialNumber == null)
            {
                SerialNumber = "---";
            }

            string version = null;
            try
            {
                version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            catch (Exception)
            {
                version = "dev";
            }

            infoLabel.Content = "S/N:  " + SerialNumber + "  |  Version " + version;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            hLog.Debug("Login button pushed");
            Perform_Login();
        }

        private void ForgotLoginButton_Click(object sender, RoutedEventArgs e)
        {
            hLog.Debug("Forgot login button pushed");
            ForgotLoginWindow forgotLoginWindow = new ForgotLoginWindow();
            forgotLoginWindow.Owner = this;
            forgotLoginWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            forgotLoginWindow.Show();
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            hLog.Debug("Contact us button pushed");
            ContactUsWindow contactUsWindow = new ContactUsWindow();
            contactUsWindow.Owner = this;
            contactUsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            contactUsWindow.Show();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            hLog.Debug("Settings button pushed");
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsWindow.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                hLog.Debug("Enter key pressed");
                Perform_Login();
            }
        }

        private async void Perform_Login()
        {
            if (UsernameTextBox.Text == "" && PasswordTextBox.Password.ToString() == "")
            {
                hLog.Error("Username and Password is empty");
                UsernameTextBox.BorderBrush = Brushes.Red;
                PasswordTextBox.BorderBrush = Brushes.Red;
                return;
            }
            else if (UsernameTextBox.Text == "")
            {
                hLog.Error("Username is empty");
                UsernameTextBox.BorderBrush = Brushes.Red;
                return;
            }
            else if (PasswordTextBox.Password.ToString() == "")
            {
                hLog.Error("Password is empty");
                PasswordTextBox.BorderBrush = Brushes.Red;
                return;
            }
            hLog.Debug("Performing login...");
            UsernameTextBox.IsEnabled = false;
            PasswordTextBox.IsEnabled = false;
            LoginButton.IsEnabled = false;
            
            try
            {
                var user = new UserLogin();
                user.username = UsernameTextBox.Text;
                user.password = PasswordTextBox.Password.ToString();

                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://" + Settings.Default.ServerIP);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsync("/api/v1/auth/login", data);
                    var result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        LoginToken loginToken = JsonConvert.DeserializeObject<LoginToken>(result);
                        App.Current.Properties["token"] = loginToken.token;
                        hLog.Info("Successfully logged in and recieved token");

                        TerminalWindow terminalWindow = new TerminalWindow();
                        terminalWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.NotFound)
                        {
                            IncorrectLogin();
                        }
                        else
                        {
                            hLog.Error("Failed to login. Status Code: " + response.StatusCode + " - Message: " + response.ReasonPhrase);
                            ConnectionError();
                        }
                    }
                }
                catch (Exception ex)
                {
                    hLog.Error("Failed to connect. Message: " + ex.Message);
                    ConnectionError();
                }
            }
            catch (Exception ex)
            {
                hLog.Error("Failed to login. Message: " + ex.Message);
                ConnectionError();
            }
        }

        private void IncorrectLogin()
        {
            hLog.Error("Incorrect username or password");
            UsernameTextBox.IsEnabled = true;
            PasswordTextBox.IsEnabled = true;
            LoginButton.IsEnabled = true;
            UsernameTextBox.Text = "";
            UsernameTextBox.BorderThickness = new Thickness(2);
            PasswordTextBox.BorderThickness = new Thickness(2);
            UsernameTextBox.BorderBrush = Brushes.Red;
            PasswordTextBox.BorderBrush = Brushes.Red;
        }

        private void ConnectionError()
        {
            hLog.Error("Failed to connect to Hale Terminal Servers.");
            MessageBox.Show("Failed to Connect to the Hale Terminal Servers. Please check your connection and try again.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            UsernameTextBox.IsEnabled = true;
            PasswordTextBox.IsEnabled = true;
            LoginButton.IsEnabled = true;
        }

        private void UsernameTextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UsernameTextBox.BorderBrush = Brushes.Transparent;
            PasswordTextBox.BorderBrush = Brushes.Transparent;
        }

        private void PasswordTextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UsernameTextBox.BorderBrush = Brushes.Transparent;
            PasswordTextBox.BorderBrush = Brushes.Transparent;
        }
    }
}
