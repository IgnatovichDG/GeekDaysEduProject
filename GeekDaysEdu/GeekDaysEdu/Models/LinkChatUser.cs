using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekDaysEdu.Models
{
    public class LinkChatUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ChatId { get; set; }
    }
}