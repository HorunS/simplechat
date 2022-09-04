﻿using Microsoft.AspNetCore.SignalR.Client;
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
        private HubConnection? _con;
        private string token = string.Empty;

        public async Task<LoginResult> Login(string address, string login)
        {
            _con = new HubConnectionBuilder().
                WithUrl(address).
                Build();
            _con.On<string, string>("ReceiveMessage", (user, message) => Console.WriteLine($"{user}:{message}"));

            await _con.StartAsync();

            try
            {
                var res = await _con.InvokeAsync<LoginResult>("Login", login);
                if (res.Success)
                {
                    token = res.Token;
                }

                return res;
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = ex.Message,
                    Token = string.Empty,
                };
            }
        }

        public async Task SendMessage(string text)
        {
            await _con!.InvokeAsync("SendMessage", token, text);
        }
    }
}
