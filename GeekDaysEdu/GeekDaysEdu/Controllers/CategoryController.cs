using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public ActionResult Categories()
        {
            List<CategoryModel> categories;
            using (var db = new Context())
            {
                categories = db.CategoryModels.OrderBy(c => c.Name).ToList();
            }
            return View(categories);
        }
    }
}