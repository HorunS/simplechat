using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class User
    {
        public string Login { get; }

        public User(string login)
        {
            Login = login;
        }
    }
}
