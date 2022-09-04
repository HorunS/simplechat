using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Managers
{
    // Manages messages
    internal interface IMessageManager
    {
        Task<int> CreateMessage(string text, string roomName, string authorLogin);

        Task<Message> GetLastMessages(string roomName);
    }
}
