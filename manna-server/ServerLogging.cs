using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace manna_server
{
    public class ServerLogging : ILogging
    {
        private string _logFilePath = @"C:\Temp\logging.txt";
        object lockObject = new object();
        static List<LogMessage> logginList = new List<LogMessage>();

        public void WriteToLog(string message, int priority)
        {
            logginList.Add(new LogMessage(message, priority));
            // sort according to priorty
            logginList.Sort();
            lock (lockObject)
            {
                using (var file = File.AppendText(_logFilePath))
                {
                    file.WriteLine(logginList[0].Message);
                    logginList.RemoveAt(0);
                }
            }
        }
    }
}
