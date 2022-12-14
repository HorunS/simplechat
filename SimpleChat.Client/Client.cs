using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleChat.Client
{

    using CH = ConsoleHelper;

    internal class Client
    {
        private readonly ChatService _srv;
        private bool _loggedIn;
        private bool _exited = false;

        public Client(ChatService srv)
        {
            _srv = srv;
            _srv.MessageReceived += _srv_MessageReceived;
            _srv.UserEnteredRoom += _srv_UserEnteredRoom;
            _srv.ConnectionClosed += _srv_ConnectionClosed;
        }

        public async Task Start()
        {
            Console.WriteLine("Welcome to chat");
            Console.WriteLine("Type /help to see available commands");

            while (!_exited)
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
                    CH.WriteWarning($"Unknown command: {command}");
                    break;
            }
        }

        private void HandleHelp()
        {
            CH.WriteText("/help - list of available commands");
            CH.WriteText("/login [login] - login to server");
            CH.WriteText("/rooms - list of available rooms");
            CH.WriteText("/room [room] - enter orcreate specified room");
        }

        private async Task HandleLogin(string[] commandParts)
        {
            if (commandParts.Length != 2)
            {
                CH.WriteError("Bad command");
                return;
            }
            var res = await _srv.Login($"https://localhost:5001/chat", commandParts[1]);

            if (res.Success)
            {
                CH.WriteNotification("Login successful");
                _loggedIn = true;
            }
            else
            {
                CH.WriteNotification($"Login failed: {res.Message}");
            }
        }

        private async Task HandleRoom(string[] commandParts)
        {
            if (commandParts.Length != 2)
            {
                CH.WriteError("Bad command");
                return;
            }

            if (!_loggedIn)
            {
                CH.WriteError("You are not logged in");
                return;
            }

            var roomName = commandParts[1];

            var res = await _srv.EnterRoom(roomName);
            if (res.Success)
            {
                CH.WriteNotification($"You entered room {roomName}");
            }
            else
            {
                CH.WriteNotification($"## Failed to enter room {roomName}: {res.Message}");
            }
        }

        private async Task HandleRoomsList(string[] commandParts)
        {
            if (commandParts.Length != 1)
            {
                CH.WriteError("Bad command");
                return;
            }

            if (!_loggedIn)
            {
                CH.WriteError("You are not logged in");
                return;
            }

            var res = await _srv.ListRooms();
            if (res.Success)
            {
                CH.WriteNotification("Available rooms:");
                for (int i = 0; i < res.Rooms!.Length; i++)
                {
                    CH.WriteText(res.Rooms[i]);
                }
            }
            else
            {
               CH.WriteNotification($"Failed to get rooms list: {res.Message}");
            }
        }

        private async Task HandleChatMessage(string message)
        {
            if (!_loggedIn)
            {
                CH.WriteError("You are not logged in");
                return;
            }

            var res = await _srv.SendMessage(message);

            if (res.Success)
            {
                CH.WriteMessage("you", message);
            }
            else
            {
                CH.WriteNotification($"Failed to send message: {res.Message}");
            }
        }

        private void _srv_MessageReceived(object? sender, MessageReceivedEventArgs e)
        {
            CH.WriteMessage(e.UserName, e.Message);
        }

        private void _srv_UserEnteredRoom(object? sender, UserEnteredRoomEventArgs e)
        {
            CH.WriteNotification($"[{e.UserName}] entered room");
        }

        private void _srv_ConnectionClosed(object? sender, ConnectionClosedEventArgs e)
        {
            CH.WriteError("Connection closed. Press <Enter> to exit");
            _exited = true;
        }
    }
}
