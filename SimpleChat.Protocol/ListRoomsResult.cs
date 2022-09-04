using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Protocol
{
    public class ListRoomsResult
    {
        public bool Success { get; set; }

        public string[]? Rooms { get; set; }

        public string? Message { get; set; }
    }
}
