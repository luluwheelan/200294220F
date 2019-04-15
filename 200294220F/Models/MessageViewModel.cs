using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _200294220F.Models
{
    public class MessageViewModel
    {
        public Message newMessage { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}