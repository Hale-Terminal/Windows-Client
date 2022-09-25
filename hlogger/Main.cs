using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace hlogger
{
    public class HLog
    {
        public static ObservableCollection<string> LogEntries { get; set; }

        private List<string> _logList;

        public List<string> LogList
        {
            get { return _logList; }
            set { _logList = value; }
        }
        public static void Debug(string message)
        {
            string LogMessage = "[" + DateTime.Now.ToString() + "] [DEBUG] - " + message;
            LogEntries.Add(LogMessage);
        }

        
        public void WriteToFile(string message)
        {
            using (StreamWriter w = File.AppendText("hterm.txt"))
            {
                w.WriteLine(message);
            }
        }

        public void WriteToConsole(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
