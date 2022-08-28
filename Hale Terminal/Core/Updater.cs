using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Squirrel;

namespace Hale_Terminal.Core
{
    class Updater
    {
        UpdateManager updateManager;
        private async void CheckForUpdate()
        {
            try
            {
                var update = UpdateManager.GitHubUpdateManager(@"https://github.com/hale-terminal/Windows");
                update.Wait();
                updateManager = update.Result;

                string currentVersion = updateManager.CurrentlyInstalledVersion().ToString();
                App.Current.Properties["currentVersion"] = currentVersion;

                var task = updateManager.CheckForUpdate();
                task.Wait();
                var updateInfo = task.Result;
                if (updateInfo.ReleasesToApply.Count > 0)
                {
                    MessageBox.Show("Update available");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CheckUpdater()
        {
            CheckForUpdate();
        }
    }
}
