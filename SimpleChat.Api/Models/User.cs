using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class User
    {
        public int Id { get; }

        public string Name { get; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
