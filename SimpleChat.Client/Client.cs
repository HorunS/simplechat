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
        private bool _loggedIn;

        public Client(ChatService srv)
        {
            _srv = srv;
            _srv.MessageReceived += _srv_MessageReceived;
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
                    else
                    {
                        await HandleChatMessage(command);
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
                    HandleHelp();
                    break;
                case "/login":
                    await HandleLogin(parts);
                    break;
                case "/room":
                    await HandleRoom(parts);
                    break;
                case "/rooms":
                    await HandleRoomsList(parts);
                    break;
                default:
                    break;
            }
        }

        private void HandleHelp()
        {
            Console.WriteLine("/help - list of available commands");
            Console.WriteLine("/login [host]:[port] [login] - login to server. E.g. /login localhost:5001 myname");
            Console.WriteLine("/rooms - list of available rooms");
            Console.WriteLine("/room [room] - enter orcreate specified room");
            Console.WriteLine("/exit - exit room");
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
                _loggedIn = true;
            }
            else
            {
                Console.WriteLine($"## Login failed: {res.Message}");
            }
        }

        private async Task HandleRoom(string[] commandParts)
        {
            if (commandParts.Length != 2)
            {
                Console.WriteLine("Bad command");
                return;
            }

            var roomName = commandParts[1];

            var res = await _srv.EnterRoom(roomName);
            if (res.Success)
            {
                Console.WriteLine($"## You entered room {roomName}");
            }
            else
            {
                Console.WriteLine($"## Failed to enter room {roomName}: {res.Message}");
            }
        }

        private async Task HandleRoomsList(string[] commandParts)
        {
            if (commandParts.Length != 1)
            {
                Console.WriteLine("Bad command");
                return;
            }

            var res = await _srv.ListRooms();
            if (res.Success)
            {
                Console.WriteLine($"## Available rooms:");
                for (int i = 0; i < res.Rooms!.Length; i++)
                {
                    Console.WriteLine(res.Rooms[i]);
                }
            }
            else
            {
                Console.WriteLine($"## Failed to get rooms list: {res.Message}");
            }
        }

        private async Task HandleChatMessage(string message)
        {
            var res = await _srv.SendMessage(message);

            if (res.Success)
            {
                Console.WriteLine($"[You]: {message}");
            }
            else
            {
                Console.WriteLine($"## Failed to send message: {res.Message}");
            }
        }

        private void _srv_MessageReceived(object? sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[{e.UserName}]: {e.Message}");
        }
    }
}
