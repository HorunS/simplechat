using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal static class Helper
    {
        public static void WriteAvailableCommands()
        {
            Console.WriteLine("/help - list of available commands");
            Console.WriteLine("/login [host]:[port] [login] - login to server. E.g. /login localhost:5001 myname");
            Console.WriteLine("/rooms - list of available rooms");
            Console.WriteLine("/room [room] - enter orcreate specified room");
            Console.WriteLine("/exit - exit room");
        }
    }
}
