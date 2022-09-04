using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal class Client
    {
        private readonly ChatService _srv;

        public Client(ChatService srv)
        {
            _srv = srv;
        }

        public async Task Start()
        {
            Console.WriteLine("Welcome to chat");
            Console.WriteLine("Type /help to see available commands");

            while (true)
            {
                var command = Console.ReadLine();

                if (!string.IsNullOrEmpty(command))
                {
                    if (command.StartsWith('/'))
                    {
                        await HandleCommand(command);
                    }

                }
            }
        }

        private async Task HandleCommand(string command)
        {
            var parts = command.Split(' ');

            switch (parts[0])
            {
                case "/help":
                    Helper.WriteAvailableCommands();
                    break;
                case "/login":
                    await HandleLogin(parts);
                    break;
                case "/rooms":
                default:
                    break;
            }
        }

        private async Task HandleLogin(string[] commandParts)
        {
            if (commandParts.Length != 3)
            {
                Console.WriteLine("Bad command");
                return;
            }
            var res = await _srv.Login($"http://{commandParts[1]}/chat", commandParts[2]);

            if (res.Success)
            {
                Console.WriteLine("## Login successful");
            }
            else
            {
                Console.WriteLine($"## Login failed: {res.Message}");
            }
        }
    }
}
