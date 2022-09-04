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

        public Room(string name)
        {
            Name = name;
        }
    }
}
