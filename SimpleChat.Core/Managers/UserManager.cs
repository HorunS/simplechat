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
        public Task<User> CreateUser(string login)
        {
            return Task.FromResult(new User(login));
        }

        public Task<User> GetUser(string login)
        {
            throw new NotImplementedException();
        }
    }
}
