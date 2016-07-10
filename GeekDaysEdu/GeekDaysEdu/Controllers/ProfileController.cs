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

        [Authorize]
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

        [Authorize]
        public ActionResult ScheduleCourse(string id)
        {
            int courseId = int.Parse(id);
            Session["courseId"] = courseId;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToSchedule(string day, int hours, int minutes)
        {
            int courseId = (int)Session["courseId"];
            var userId = User.Identity.GetUserId();
            using (var db = new Context())
            {
                var link = db.LinkUsersCourses.First(l => l.UserId == userId && l.ResourceModel.ResourceId == courseId);
                db.Schedules.Add(new Schedule
                {
                    Day = day,
                    Link = link,
                    Time = $"{hours}:{minutes}"
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Schedule()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.Days = new [] {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
            List<Schedule> schedules;
            using (var db = new Context())
            {
                schedules = db.Schedules
                    .Where(l => l.Link.UserId == userId)
                    .Include(s => s.Link)
                    .Include(s => s.Link.ResourceModel)
                    .ToList();
            }
            return View(schedules);
        }
    }
}