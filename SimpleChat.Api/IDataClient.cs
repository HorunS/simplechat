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

        Task<int> CreateRoom(string login, string name);

        Task<Room[]> GetRooms();

        #endregion

        #region Message

        Task<int> CreateMessage(string text, string roomName, int authorLogin);

        Task<Message> GetLastMessages(string roomName);

        #endregion
    }
}
