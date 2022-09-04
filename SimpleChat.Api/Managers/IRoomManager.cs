using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Managers
{
    // Manages rooms
    internal interface IRoomManager
    {
        Task<string> CreateRoom(string ownerLogin, string name);

        Task<Room[]> GetRooms();
    }
}
