using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal class UserEnteredRoomEventArgs: EventArgs
    {
        public string UserName { get; }

        public UserEnteredRoomEventArgs(string userName)
        {
            UserName = userName;
        }
    }
}
