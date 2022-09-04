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
        Task<int> CreateRoom(int userId, string name);

        Task<Room[]> GetRooms();

        Task<Room> GetRoom(int roomId);
    }
}
