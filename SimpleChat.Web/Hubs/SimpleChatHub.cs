using Microsoft.AspNetCore.SignalR;

namespace SimpleChat.Web.Hubs
{
    public class SimpleChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
