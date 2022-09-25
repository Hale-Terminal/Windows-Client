using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hale_Terminal.Core;
using Hale_Terminal.Model;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Hale_Terminal.ViewModel
{
    class LoginViewModel : ObservableObject, INotifyPropertyChanged
    {
        private List<CosmosModel> _servers;


        public List<CosmosModel> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }
        public ObservableCollection<CosmosModel> Cosmos { get; set; }

        public RelayCommand LoginCommand { get; set; }


        private void ExecuteMyMethod(object parameter)
        {
            MessageBox.Show("Boop");
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            Cosmos = new ObservableCollection<CosmosModel>();
            LoginCommand = new RelayCommand(o =>
            {
                var cosmosDetails = API.GetCall("/cosmos/v1/apps/dolphin");
                if (cosmosDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Servers = cosmosDetails.Result.Content.ReadAsAsync<List<CosmosModel>>().Result;
                    //MessageBox.Show(boop);
                    foreach (var item in Servers)
                    {
                        var dolphinDetails = API.GetCall($"/cosmos/v1/apps/dolphin/{item.instance_id}");
                        if (dolphinDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            DolphinModel dolphinModel = dolphinDetails.Result.Content.ReadAsAsync<DolphinModel>().Result;
                            if (dolphinModel.status == "UP")
                            {
                                MessageBox.Show(dolphinModel.ip_address);
                            }
                        }
                    }
                }
            });


        }
    }
}
