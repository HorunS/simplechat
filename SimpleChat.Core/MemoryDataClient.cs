using SimpleChat.Api;
using SimpleChat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleChat.Api.IDataClient;

namespace SimpleChat.Core
{
    public class MemoryDataClient : IDataClient
    {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private object _lock = new object();

        #region Users

        public Task<User> CreateUser(string login)
        {
            lock (_lock)
            {
                if (_users.ContainsKey(login))
                {
                    throw new ApplicationException($"User {login} already exists");
                }

                var user = new User(login);
                _users.Add(login, user);

                return Task.FromResult(user);
            }
        }

        public Task<User?> GetUser(string login)
        {
            return Task.FromResult(_users.TryGetValue(login, out var user) ? user : null);
        }

        #endregion

        public Task<int> CreateMessage(string text, string roomName, int authorLogin)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateRoom(string login, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetLastMessages(string roomName)
        {
            throw new NotImplementedException();
        }

        public Task<Room[]> GetRooms()
        {
            throw new NotImplementedException();
        }


    }
}
