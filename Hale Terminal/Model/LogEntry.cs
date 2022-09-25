using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hale_Terminal.Model
{
    public class LogEntry
    {
        public string Timestamp { get; set; }
        public string System { get; set; }
        public string Message { get; set; }
    }
}
