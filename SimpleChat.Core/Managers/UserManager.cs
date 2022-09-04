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
    public class UserManager : IUserManager
    {

        //private IDataClient _dataClient;

        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private object _lock = new object();

        public Task<string> CreateUser(string login)
        {
            lock (_lock)
            {
                var user = GetUserByLogin(login);

                if (user != null)
                {
                    throw new ApplicationException($"User with login {login} alredy exists");
                }

                user = new User(login);
                var token = Guid.NewGuid().ToString();

                _users.Add(token, user);

                return Task.FromResult(token);
            }
        }

        public Task<User?> GetUser(string token)
        {
            return Task.FromResult(_users.TryGetValue(token, out var user) ? user : null);
        }

        private User? GetUserByLogin(string login)
        {
            var user = _users.FirstOrDefault(x => x.Value.Login == login).Value;
            return user;
        }
    }
}
