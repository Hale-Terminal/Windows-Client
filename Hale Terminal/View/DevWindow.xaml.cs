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
    /// Interaction logic for DevWindow.xaml
    /// </summary>
    public partial class DevWindow : Window
    {
        HLog log = new HLog();
        public DevWindow()
        {
            InitializeComponent();
            log.Debug("Started developer window");

            LogEntryList.ItemsSource = HLogShare.LogEntries;
        }
    }
}
