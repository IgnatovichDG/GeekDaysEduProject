using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeekDaysEdu.Models;

namespace GeekDaysEdu.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string id)
        {
            List<ResourceModel> courses;
            try
            {
                int idInt = int.Parse(id);
                using (var db = new Context())
                {
                    courses = db.ResourceModels
                        .Where(r => r.Category.CategoryID == idInt)
                        .Include(r => r.Category)
                        .ToList();
                }
            }
            catch (Exception)
            {
                using (var db = new Context())
                {
                    courses = db.ResourceModels
                        .Include(r => r.Category)
                        .ToList();
                }
            }

            return View(courses);
        }
    }
}