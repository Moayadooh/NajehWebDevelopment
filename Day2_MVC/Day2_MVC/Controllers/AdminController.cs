using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2_MVC.ViewModel;
using Day2_MVC.Models;

namespace Day2_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            var obj = new Humen_Cars();
            obj.Humen = Human.GetHumen();
            obj.Cars = Car.GetCars();
            return View(obj);
        }

        public ActionResult GetNames()
        {
            return PartialView();
        }
    }
}