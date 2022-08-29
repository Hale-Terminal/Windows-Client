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
using Hale_Terminal.Core;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for LoginStartView.xaml
    /// </summary>
    public partial class LoginStartView : Page
    {
        public LoginStartView()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(new LoginConnectingView());
            };
        }
    }
}
