using System;
using System.ComponentModel.DataAnnotations;

namespace GeekDaysEdu.Models
{
    public class CommentModel
    {
        [Key]
        public string CommentID { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public string Userid { get; set; }
    }
}