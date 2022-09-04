using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api.Models
{
    public class Message
    {
        public int Id { get; }

        public string Text { get; }

        public DateTime Date { get; }

        public int RoomId { get; }

        public int AuthorId { get; }

        public Message(int id, string text, DateTime date, int roomId, int authorId)
        {
            Id = id;
            Text = text;
            Date = date;
            RoomId = roomId;
            AuthorId = authorId;
        }
    }
}
