using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EduBot.Models;

namespace EduBot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Task.Factory.StartNew(Methods.SendDeadlinesInLoop);

            return View();
        }
    }
}
