using SimpleChat.Api;
using SimpleChat.Api.Managers;
using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Managers
{
    public class RoomManager : IRoomManager
    {
        private Dictionary<string, Room> _rooms = new Dictionary<string, Room>();
        private object _lock = new object();

        public Task<Room> CreateRoomIfNotExist(string name)
        {
            lock (_lock)
            {
                if (!_rooms.TryGetValue(name, out var room))
                {
                    room = new Room(name);
                    _rooms.Add(name, room);
                }
                return Task.FromResult(room);
            }
        }

        public Task<Room[]> GetRooms()
        {
            lock (_lock)
            {
                return Task.FromResult(_rooms.Select(x => x.Value).ToArray());
            }
        }

        public Task<Room> GetRoom(string name)
        {
            lock (_lock)
            {
                return Task.FromResult(_rooms[name]);
            }
        }
    }
}
