using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2_MVC.ViewModel;  //To access classes in the ViewModel
using Day2_MVC.Models;

namespace Day2_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            var model = new Humen_Cars();
            model.Humen = Human.GetHumen();
            model.Cars = Car.GetCars();
            return View(model);
        }

        public ActionResult GetNames()
        {
            return PartialView();
        }
    }
}