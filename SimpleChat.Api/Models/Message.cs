using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class Message
    {
        public string Text { get; }

        public DateTime Date { get; }

        public string RoomName { get; }

        public string AuthorLogin { get; }

        public Message(string text, DateTime date, string roomName, string authorLogin)
        {
            Text = text;
            Date = date;
            RoomName = roomName;
            AuthorLogin = authorLogin;
        }
    }
}
