using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class Room
    {
        public string Name { get; }

        public string OwnerLogin { get; }

        public Room(int id, string name, string ownerLogin)
        {
            Name = name;
            OwnerLogin = ownerLogin;
        }
    }
}
