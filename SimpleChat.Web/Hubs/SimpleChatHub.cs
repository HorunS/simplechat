using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using SimpleChat.Api.Managers;
using SimpleChat.Api.Models;
using SimpleChat.Protocol;

namespace SimpleChat.Web.Hubs
{

    public class SimpleChatHub : Hub
    {
        private IUserManager _userManager;
        private IRoomManager _roomManager;

        public SimpleChatHub(IUserManager userManager, IRoomManager roomManager)
        {
            _userManager = userManager;
            _roomManager = roomManager;
        }

        public async Task<LoginResult> Login(string login)
        {
            try
            {
                var token = await _userManager.CreateUser(login);
                return new LoginResult
                {
                    Success = true,
                    Token = token,
                };
            }
            catch (Exception e)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        public async Task<ListRoomsResult> ListRooms(string token)
        {
            var user = await _userManager.GetUser(token);

            if (user != null)
            {
                var rooms = await _roomManager.GetRooms();

                return new ListRoomsResult
                {
                    Success = true,
                    Rooms = rooms.Select(r => r.Name).ToArray(),
                };
            }
            else
            {
                return new ListRoomsResult
                {
                    Success = false,
                    Message = "User not found",
                };
            }
        }

        public async Task<EnterRoomResult> EnterRoom(string token, string roomName)
        {
            var user = await _userManager.GetUser(token);

            if (user != null)
            {
                await _roomManager.CreateRoomIfNotExist(roomName);
                user.CurrentRoom = roomName;

                await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

                await Clients.OthersInGroup(roomName).SendAsync("UserEnteredRoom", user.Login);

                return new EnterRoomResult
                {
                    Success = true,
                };
            }
            else return new EnterRoomResult
            {
                Success = false,
                Message = $"User not found",
            };
        }

        public async Task<SendMessageResult> SendMessage(string token, string message)
        {
            var user = await _userManager.GetUser(token);

            if (user != null)
            {
                if (user.CurrentRoom != null)
                {
                    await Clients.OthersInGroup(user.CurrentRoom).SendAsync("ReceiveMessage", user.Login, message);
                    return new SendMessageResult
                    {
                        Success = true,
                    };
                }
                else
                {
                    return new SendMessageResult
                    {
                        Success = false,
                        Message = "You are not in room",
                    };
                }
            }
            else
            {
                return new SendMessageResult
                {
                    Success = false,
                    Message = "User not found",
                };
            }
        }


    }
}
