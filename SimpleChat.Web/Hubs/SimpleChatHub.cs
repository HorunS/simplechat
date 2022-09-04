using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using SimpleChat.Api.Managers;
using SimpleChat.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleChat.Web.Hubs
{
    
    public class SimpleChatHub : Hub
    {
        private IUserManager _userManager;

        public SimpleChatHub(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
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
            catch(Exception e)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = e.Message
                };
            }

        }
    }
}
