using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal static class ConsoleHelper
    {
        public static void WriteNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"## {message}");
            Console.ResetColor();
        }

        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"!! {message}");
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!! {message}");
            Console.ResetColor();
        }

        public static void WriteText(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteMessage(string user, string message)
        {
            Console.WriteLine($"[{user}]: {message}");
        }
    }
}
