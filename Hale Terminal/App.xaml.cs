using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hale_Terminal.Model;
using Hale_Terminal.View;
using Hale_Terminal.Core;
using System.Net;
using System.Management;
using Microsoft.Win32;
using System.Text;
using System.IO;
using persist;

namespace Hale_Terminal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        HLog log = new HLog();
        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                //DB.CreateTable();
                DB.InsertData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            log.Info("Starting Application");
            base.OnStartup(e);
            StartUp();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            //Window1 window1 = new Window1();
            //window1.Show();

        }

        private void StartUp()
        {
            try
            {
                log.Info("Running Startup Tasks");

                log.Info("Getting Public IP Address...");
                string externalIPString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                var externalIP = IPAddress.Parse(externalIPString);
                log.Info("Public IP Address ............ :" + externalIP);

                log.Info("Getting OS Version...");
                var OSVersion = Environment.OSVersion.ToString();
                log.Info("OS Version ............. :" + OSVersion);

                //CurrentDirectory
                log.Info("Getting Current Directory...");
                var currentDirectory = Environment.CurrentDirectory.ToString();
                App.Current.Properties["directory"] = currentDirectory;
                log.Info("Current Directory ........ :" + currentDirectory);

                //MachineName
                log.Info("Getting Machine Name...");
                var machineName = Environment.MachineName.ToString();
                log.Info("Machine Name ........ :" + machineName);


                //SystemDirectory


                //Application Version


                //Application Serial Number


                //Check Server Connection


                //Check for Update


                //Build Server List Cache


                //Build Local Database with Updated Data



            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                MessageBox.Show("Error on Start Up");
                Application.Current.Shutdown();
            }
        }
    }
}
