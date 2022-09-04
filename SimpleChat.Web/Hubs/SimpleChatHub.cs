using Microsoft.AspNetCore.SignalR;
using SimpleChat.Api.Managers;
using SimpleChat.Protocol;

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
                await _userManager.CreateUser(login);
                return new LoginResult
                {
                    Success = true
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
