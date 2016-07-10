using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeekDaysEdu.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string UserId { get; set; }
        public ResourceModel ResourceModel { get; set; }
        public int Status { get; set; }
    }
}