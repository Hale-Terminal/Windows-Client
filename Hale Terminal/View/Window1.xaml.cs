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

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CommandTextBox.Focusable = false;
        }


        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (CommandTextBox.Focus() & e.Key != Key.Enter)
            {
                return;
            }
            if (e.Key == Key.A || e.Key == Key.B || e.Key == Key.C || e.Key == Key.D || e.Key == Key.E || e.Key == Key.F || e.Key == Key.G || e.Key == Key.H || e.Key == Key.I || e.Key == Key.J || e.Key == Key.K || e.Key == Key.L || e.Key == Key.M || e.Key == Key.N || e.Key == Key.O || e.Key == Key.P || e.Key == Key.Q || e.Key == Key.R || e.Key == Key.S || e.Key == Key.T || e.Key == Key.U || e.Key == Key.V || e.Key == Key.W || e.Key == Key.X || e.Key == Key.Y || e.Key == Key.Z)
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    switch (e.Key)
                    {
                        case Key.S:
                            FrameControl("View/SearchResultsPage.xaml");
                            break;
                        case Key.N:
                            MessageBox.Show("News");
                            break;
                        case Key.L:
                            MessageBox.Show("Log Off");
                            break;
                        case Key.Q:
                            MessageBox.Show("Back");
                            break;
                        case Key.W:
                            MessageBox.Show("Forward");
                            break;
                        case Key.Z:
                            TerminalWindow terminalWindow = new TerminalWindow();
                            terminalWindow.Show();
                            break;
                        case Key.C:
                            if (ToolRow.Visibility == Visibility.Visible)
                            {
                                ToolRow.Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                ToolRow.Visibility = Visibility.Visible;
                            }
                            break;
                    }
                }
                else
                {
                    CommandTextBoxGrid.SetValue(Grid.ColumnSpanProperty, 2);
                    CommandTextBox.Width = this.Width - 100;
                    CommandTextBox.HorizontalAlignment = HorizontalAlignment.Left;
                    CommandTextBox.Text += e.Key.ToString();
                }
            }
            else
            {
                if (e.Key == Key.S && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                }
                else
                {
                    switch (e.Key)
                    {
                        case Key.Enter:
                            parse(CommandTextBox.Text);
                            CommandTextBox.Text = "";
                            CommandTextBoxGrid.SetValue(Grid.ColumnSpanProperty, 1);
                            CommandTextBox.Width = 350;
                            break;
                        case Key.Space:
                            CommandTextBox.Text += " ";
                            break;
                        case Key.Back:
                            if (CommandTextBox.Text != "")
                            {
                                string currentText = CommandTextBox.Text;
                                CommandTextBox.Text = currentText.Remove(currentText.Length - 1, 1);
                            }
                            break;
                        case Key.Escape:
                            //typeof(Button).GetMethod("set_IsPressed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(CancelButton, new object[] { true });
                            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
                            //dispatcherTimer.Tick += new EventHandler(timer_Tick);
                            //dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);
                            //dispatcherTimer.Start();
                            //CancelButton.IsChecked = true;
                            //typeof(Button).GetMethod("set_IsPressed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(CancelButton, new object[] { false });
                            //CancelButton.Click += new RoutedEventHandler(CancelButton_Click);
                            //CancelButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            //CancelButton.Background = new SolidColorBrush(Colors.Aqua);
                            CommandTextBox.Text = "";
                            CommandTextBoxGrid.SetValue(Grid.ColumnSpanProperty, 1);
                            CommandTextBox.Width = 350;
                            break;
                        case Key.F1:
                            MessageBox.Show("Help");
                            break;
                        case Key.F2:
                            CommandTextBox.Text += " GOVT";
                            break;
                        case Key.F3:
                            CommandTextBox.Text += " CORP";
                            break;
                        case Key.F4:
                            CommandTextBox.Text += " MTGE";
                            break;
                        case Key.F5:
                            MessageBox.Show("Money Markets");
                            break;
                        case Key.F6:
                            CommandTextBox.Text += " MUNI";
                            break;
                        case Key.F7:
                            MessageBox.Show("PFD");
                            break;
                        case Key.F8:
                            CommandTextBox.Text += " EQU";
                            break;
                        case Key.F9:
                            CommandTextBox.Text += " COMD";
                            break;
                        case Key.F10:
                            CommandTextBox.Text += " INDX";
                            break;
                        case Key.F11:
                            CommandTextBox.Text += " CURN";
                            break;
                        case Key.F12:
                            MessageBox.Show("Portfolio");
                            break;
                        case Key.PrintScreen:
                            MessageBox.Show("Print");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            typeof(Button).GetMethod("set_IsPressed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(CancelButton, new object[] { false });
            CommandTextBox.Text = "";
        }

        private void parse(string command)
        {
            if (command == null)
            {
                return;
            }
            else
            {
                if (command == "HOME")
                {
                    FrameControl("View/HomePage.xaml");
                }
                else
                {
                    if (command == "BA US EQU")
                    {
                        FrameControl("View/EquityView.xaml");
                    }
                    else
                    {
                        if (command == "WIN")
                        {
                            this.Width = 715;
                            this.Height = 600;
                        }
                        else
                        {
                            if (command == "BIO ANDREW HALE")
                            {
                                FrameControl("View/BioPage.xaml");
                            }
                        }
                    }
                }
            }
        }

        private void FrameControl(string pathname)
        {
            TerminalFrame.Navigate(new System.Uri(pathname, UriKind.RelativeOrAbsolute));
            CommandTextBox.Text = "";
        }


        private void navigateBackButton(object sender, RoutedEventArgs e)
        {
            if (TerminalFrame.NavigationService.CanGoBack)
            {
                TerminalFrame.NavigationService.GoBack();
            }
        }

        private void navigateForwardButton(object sender, RoutedEventArgs e)
        {
            if (TerminalFrame.NavigationService.CanGoForward)
            {
                TerminalFrame.NavigationService.GoForward();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //typeof(Button).GetMethod("set_IsPressed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(CancelButton, new object[] { true });
            CommandTextBox.Text = "";
        }
    }
}
