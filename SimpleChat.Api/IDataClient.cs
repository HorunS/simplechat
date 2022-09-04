using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api
{
    // Abstraction for data-access layer
    public interface IDataClient
    {
        #region User

        Task<User> CreateOrGetUser(string login);

        #endregion

        #region Room

        Task<int> CreateRoom(int userId, string name);

        Task<Room[]> GetRooms();

        Task<Room> GetRoom(int roomId);

        #endregion

        #region Message

        Task<int> CreateMessage(string text, int roomId, int authorId);

        Task<Message> GetLastMessages(int roomId);

        #endregion
    }
}
