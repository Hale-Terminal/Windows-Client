using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hale_Terminal.Model;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Windows;

namespace Hale_Terminal.Core
{
    class Cosmos
    {
        private List<CosmosModel> instanceList;

        private List<DolphinModel> serverList;

        private List<ServerModel> Servers;

        
        public void GetServers()
        {
            
        }

        private void GetListOfDolphinServers()
        {
            var cosmosResponse = API.GetCall("/cosmos/v1/apps/dolphin");
            if (cosmosResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                instanceList = cosmosResponse.Result.Content.ReadAsAsync<List<CosmosModel>>().Result;
                if (instanceList.Count > 0)
                {
                    foreach (var instance in instanceList)
                    {
                        var instanceResponse = API.GetCall($"/cosmos/v1/apps/dolphin/{instance.instance_id}");
                        if (instanceResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            DolphinModel instanceDetail = instanceResponse.Result.Content.ReadAsAsync<DolphinModel>().Result;
                            if (instanceDetail.status == "UP")
                            {
                                serverList.Add(instanceDetail);
                            }
                        }
                    }
                }
            }
        }

        private void DetermineBestConnection()
        {
            ServerModel BestServer = new ServerModel();
            Ping pinger = new Ping();
            
            foreach (var server in serverList)
            {
                ServerModel serverModel = new ServerModel();
                serverModel.ip_address = server.ip_address;

                PingReply serverReply = pinger.Send(server.ip_address);
                serverModel.trip_time = serverReply.RoundtripTime;

                Servers.Add(serverModel);

                if (BestServer != null)
                {
                    if (serverModel.trip_time < BestServer.trip_time)
                    {
                        BestServer = serverModel;
                    }
                }
                else
                {
                    BestServer = serverModel;
                }
            }

            if (BestServer != null)
            {
                App.Current.Properties["ActiveServer"] = BestServer.ip_address;
            }
            else
            {
                MessageBox.Show("Failed to find best server");
            }
        }
    }
}
