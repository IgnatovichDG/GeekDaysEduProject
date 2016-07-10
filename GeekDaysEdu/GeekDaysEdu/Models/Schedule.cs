using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekDaysEdu.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Link Link { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}