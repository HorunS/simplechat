using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Managers
{
    // Manages rooms
    public interface IRoomManager
    {
        Task<Room> CreateRoomIfNotExist(string name);

        Task<Room[]> GetRooms();

        Task<Room> GetRoom(string name);

    }
}
