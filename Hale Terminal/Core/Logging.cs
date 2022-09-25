using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hale_Terminal.Model;
using System.IO;

namespace Hale_Terminal.Core
{
    class HLogShare
    {
        public static ObservableCollection<LogEntry> LogEntries { get; set; } = new ObservableCollection<LogEntry>();
        
    }

    class HLog
    {
        public void Debug(string message)
        {
            HLogShare.LogEntries.Add(new LogEntry
            {
                Message = message,
                System = "DEBUG",
                Timestamp = DateTime.Now.ToString()
            });
            string consoleMessage = DateTime.Now.ToString() + " - DEBUG - " + message;
            WriteToFile(consoleMessage);
        }

        public void Info(string message)
        {
            HLogShare.LogEntries.Add(new LogEntry
            {
                Message = message,
                System = "INFO",
                Timestamp = DateTime.Now.ToString()
            });
            string consoleMessage = DateTime.Now.ToString() + " - INFO - " + message;
            WriteToFile(consoleMessage);
        }

        public void Warn(string message)
        {
            HLogShare.LogEntries.Add(new LogEntry
            {
                Message = message,
                System = "WARN",
                Timestamp = DateTime.Now.ToString()
            });
            string consoleMessage = DateTime.Now.ToString() + " - WARN - " + message;
            WriteToFile(consoleMessage);
        }

        public void Error(string message)
        {
            HLogShare.LogEntries.Add(new LogEntry
            {
                Message = message,
                System = "ERROR",
                Timestamp = DateTime.Now.ToString()
            });
            string consoleMessage = DateTime.Now.ToString() + " - ERROR - " + message;
            WriteToFile(consoleMessage);
        }

        public void Critical(string message)
        {
            HLogShare.LogEntries.Add(new LogEntry
            {
                Message = message,
                System = "CRITICAL",
                Timestamp = DateTime.Now.ToString()
            });
            string consoleMessage = DateTime.Now.ToString() + " - CRITICAL - " + message;
            WriteToFile(consoleMessage);
        }

        public void ClearData()
        {
            HLogShare.LogEntries.Clear();
        }

        public void WriteToFile(string message)
        {
            //using (StreamWriter w = File.AppendText("hterm.txt"))
            //{
            //    w.WriteLine(message);
            //}
        }
    }
}
