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
        private HubConnection? _con;
        private string token = string.Empty;

        public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

        public async Task<LoginResult> Login(string address, string login)
        {
            _con = new HubConnectionBuilder().
                WithUrl(address).
                Build();
            _con.On<string, string>(
                "ReceiveMessage", 
                (user, message) => MessageReceived?.Invoke(this, new MessageReceivedEventArgs(user, message)));

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


        public async Task<ListRoomsResult> ListRooms()
        {
            return await _con!.InvokeAsync<ListRoomsResult>("ListRooms", token);
        }

        public async Task<EnterRoomResult> EnterRoom(string roomName)
        {
            return await _con!.InvokeAsync<EnterRoomResult>("EnterRoom", token, roomName);
        }

        public async Task<SendMessageResult> SendMessage(string text)
        {
            return await _con!.InvokeAsync<SendMessageResult>("SendMessage", token, text);
        }
    }
}
