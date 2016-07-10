using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekDaysEdu.Models;
using Microsoft.AspNet.Identity;

namespace GeekDaysEdu.Controllers
{
    public class ResourceModelsController : Controller
    {
        private Context db = new Context();

        // GET: ResourceModels
        public ActionResult Index()
        {
            return View(db.ResourceModels.ToList());
        }

        // GET: ResourceModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceModel resourceModel = db.ResourceModels.Find(id);
            if (resourceModel == null)
            {
                return HttpNotFound();
            }

            var currentUserId = User.Identity.GetUserId();
            ViewBag.Taken = db.LinkUsersCourses.Any(l => l.UserId == currentUserId && l.ResourceModel.ResourceId == id);

            return View(resourceModel);
        }

        // GET: ResourceModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourceId,Name,Type,URL,Disciption,LinkToImg,Score")] ResourceModel resourceModel)
        {
            if (ModelState.IsValid)
            {
                db.ResourceModels.Add(resourceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceModel);
        }

        // GET: ResourceModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceModel resourceModel = db.ResourceModels.Find(id);
            if (resourceModel == null)
            {
                return HttpNotFound();
            }
            return View(resourceModel);
        }

        // POST: ResourceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceId,Name,Type,URL,Disciption,LinkToImg,Score")] ResourceModel resourceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceModel);
        }

        // GET: ResourceModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceModel resourceModel = db.ResourceModels.Find(id);
            if (resourceModel == null)
            {
                return HttpNotFound();
            }
            return View(resourceModel);
        }

        // POST: ResourceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceModel resourceModel = db.ResourceModels.Find(id);
            db.ResourceModels.Remove(resourceModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult TakeCourse(string id)
        {
            int courseId = int.Parse(id);
            var course = db.ResourceModels.Find(courseId);
            db.LinkUsersCourses.Add(new Link()
            {
                ResourceModel = course,
                UserId = User.Identity.GetUserId(),
                Status = 0
            });
            db.SaveChanges();
            return RedirectToAction("Categories", "Category");
        }
    }
}
