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

        private IDataClient _dataClient;

        public UserManager(IDataClient dataClient)
        {
            _dataClient = dataClient;
        }

        public async Task<string> CreateUser(string login)
        {
            var user = await _dataClient.GetUserByLogin(login);

            if (user != null)
            {
                throw new ApplicationException($"User with login {login} alredy exists");
            }

            return await _dataClient.CreateUser(login);
        }

        public async Task<User?> GetUser(string login)
        {
            return await _dataClient.GetUser(login);
        }
    }
}
