using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manna_server
{
    public class LogMessage: IComparable
    {
        public string Message { get; private set; }
        public int Priority { get; }

        public LogMessage(string message, int priority)
        {
            Message = message;
            Priority = priority;
        }

        /// <summary>
        /// Comparing the priority of the messages
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            var message = obj as LogMessage;
            return this.Priority > message.Priority ? -1 : 1;
        }
    }
}
