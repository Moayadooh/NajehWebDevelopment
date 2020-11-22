using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Display()
        {
            ViewBag.Im = "I'm Human";
            return View();
        }

        public ActionResult UserProfile()
        {
            ViewBag.Name = "Eyad";
            ViewBag.Age = 1;
            return View();
        }
    }
}