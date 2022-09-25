using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hale_Terminal.Model
{
    public class AdapterModel
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public string PhysicalAddress { get; set; }
        public string ProxyEnabled { get; set; }
        public string DHCPEnabled { get; set; }
        public string IPAddress { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }
        public string LeaseObtained { get; set; }
        public string LeaseExpires { get; set; }
    }
}
