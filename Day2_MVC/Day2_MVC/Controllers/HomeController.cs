using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2_MVC.Models; //To access classes in the Models

namespace Day2_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var obj = new Human();
            ViewData["Name"] = obj.Name = "Eyad";
            ViewData["Age"] = obj.Age = 1;

            var human = Human.GetHumen();
            ViewBag.hm = human;
            ViewData["hm"] = human;
            return View(human);
        }

        public ActionResult DisplayList()
        {
            return View(Day2_MVC.Models.Human.GetHumen());
        }

        public ActionResult DisplayDetails()
        {
            return View(Day2_MVC.Models.Human.GetHumen().FirstOrDefault());
        }
    }
}