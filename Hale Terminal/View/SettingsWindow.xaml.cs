using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hale_Terminal.Model;
using System.Net;
using System.Diagnostics;
using Hale_Terminal.Core;

namespace Hale_Terminal.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    
    public partial class SettingsWindow : Window
    {
        public ObservableCollection<AdapterModel> AdapterModels;
        public SettingsWindow()
        {
            InitializeComponent();

            HLog hLog = new HLog();

            AdapterModels = new ObservableCollection<AdapterModel>();
            AdapterList.ItemsSource = AdapterModels;
            //ShowNetworkInterfaces();
            

            LogEntryList.ItemsSource = HLogShare.LogEntries;

            GridView gridView = new GridView();
            gridView = (GridView)LogEntryList.View;
            foreach (GridViewColumn column in gridView.Columns)
            {
                column.Width = column.ActualWidth;
                column.Width = Double.NaN;
            }

            
        }

        public void ShowNetworkInterfaces()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string ipAddress = "";
                IPInterfaceProperties properties = nic.GetIPProperties();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ip.Address.ToString();
                        }
                    }
                }

                AdapterModels.Add(new AdapterModel
                {
                    Description = "Adapter Description                  :" + nic.Description,
                    Status = "Adapter Status                           :" + nic.OperationalStatus.ToString(),
                    PhysicalAddress = "Physical Address                       :" + nic.GetPhysicalAddress().ToString(),
                    ProxyEnabled = "WINS Proxy Enabled                  :Error",
                    DHCPEnabled = "DHCP Enabled                            :" + properties.IsDynamicDnsEnabled,
                    IPAddress = "IP Address                                  :" + ipAddress,
                    SubnetMask = "Subnet Mask                               :Error",
                    DefaultGateway = "Default Gateway                        :Error",
                    LeaseObtained = "Lease Obtained                         :Error",
                    LeaseExpires = "Lease Expires                            :Error"
                });

            }

        }
    }
}
