using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using manna_server;


namespace manna_server
{

    // Client side
    class Program
    {
        static void Main(string[] args)
        {
            ILogging logging = new ServerLogging();
            List<LogMessage> messages = new List<LogMessage>();
            int index = 1;
            for (int i = 1; i <= 10000; i++)
            {
                messages.Add(new LogMessage($"Logging message - {i}", i));

            }
            Console.WriteLine("Writing to log...");
            Parallel.ForEach(messages, message => logging.WriteToLog(message.Message, message.Priority));
        }
    }
}

