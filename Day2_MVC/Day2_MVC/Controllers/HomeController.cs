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
            var human = Human.GetHumen();
            return View(human);
        }
    }
}