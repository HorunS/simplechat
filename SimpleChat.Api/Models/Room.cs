using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class Room
    {
        public int Id { get; }

        public string Name { get; }

        public int OwnerId { get; }

        public Room(int id, string name, int ownerId)
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
        }
    }
}
