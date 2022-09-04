using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal class MessageReceivedEventArgs: EventArgs
    {
        public string UserName { get; }
        public string Message { get; }

        public MessageReceivedEventArgs(string userName, string message)
        {
            UserName = userName;
            Message = message;
        }
    }
}
