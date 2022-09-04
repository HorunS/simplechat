using Microsoft.AspNetCore.SignalR.Client;
using SimpleChat.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Client
{
    internal class ChatService
    {
        private HubConnection _con;
        private string? _login;

        public ChatService()
        {
            _con = new HubConnectionBuilder().WithUrl("http://localhost:5001/chat").Build();
            _con.On<string, string>("ReceiveMessage", (user, message) => Console.WriteLine($"{user}:{message}"));
        }

        public async Task Start(string login)
        {
            _login = login;
            await _con.StartAsync();

            try
            {
                await _con.InvokeAsync("Login", login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SendMessage(string text)
        {
            await _con.InvokeAsync("SendMessage", _login, text);
        }
    }
}
