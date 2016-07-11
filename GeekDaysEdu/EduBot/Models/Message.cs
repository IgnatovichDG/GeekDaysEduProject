using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduBot.Models
{
    public class Message
    {
        public int Message_Id { get; set; }
        public Chat Chat { get; set; }
        public string Text { get; set; }
    }
}