using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GeekDaysEdu.Models;

namespace GeekDaysEdu
{
    public class Context: DbContext
    {
        public Context() : base("NiceConnection")
        {
            
        }
        public DbSet<ResourceModel> ResourceModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
    }
}