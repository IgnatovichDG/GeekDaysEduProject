using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeekDaysEdu.Models;
using Microsoft.AspNet.Identity;

namespace GeekDaysEdu.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            List<Link> courses;
            var userId = User.Identity.GetUserId();
            using (var db = new Context())
            {
                courses = db.LinkUsersCourses
                    .Where(l => l.UserId == userId)
                    .Include(l => l.ResourceModel)
                    .OrderBy(l => l.ResourceModel.Name)
                    .ToList();
            }
            return View(courses);
        }
    }
}