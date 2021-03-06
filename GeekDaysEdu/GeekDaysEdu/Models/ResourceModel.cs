﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GeekDaysEdu.Models
{
    public class ResourceModel
    {
        [Key]
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string URL { get; set; }

        public string Disciption { get; set; }

        public string LinkToImg { get; set; }

        public double Score { get; set; }

        public CategoryModel Category { get; set; }

        public List<string> Tags { get; set; }

        public string getSmallDiscr()
        {
            string result = Disciption;
            if (result.Length > 140)
            {
                int i = 141;
                while (result[i] != ' ') { i--; }
                result = result.Substring(0, i) + "...";
            }
            return result;
        }
    }
}