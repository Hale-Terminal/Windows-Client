using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hale_Terminal.Model
{
    class DolphinModel
    {
        public string app { get; set; }
        public string ami_id { get; set; }
        public string instance_type { get; set; }
        public string cpu_usage { get; set; }
        public string port { get; set; }
        public string ip_address { get; set; }
        public string status { get; set; }
        public string availability_zone { get; set; }
        public string ami_launch_index { get; set; }
        public string timestamp { get; set; }
        public string ram_usage { get; set; }
        public string instance_id { get; set; }
    }
}
