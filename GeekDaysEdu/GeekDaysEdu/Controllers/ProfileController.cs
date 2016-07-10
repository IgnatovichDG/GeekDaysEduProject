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

        public ActionResult MarkCompleted(string id)
        {
            int courseId = int.Parse(id);
            var userId = User.Identity.GetUserId();
            using (var db = new Context())
            {
                var link = db.LinkUsersCourses.First(l => l.UserId == userId && l.ResourceModel.ResourceId == courseId);
                link.Status = 1;
                db.LinkUsersCourses.Attach(link);
                db.Entry(link).Property(l => l.Status).IsModified = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}