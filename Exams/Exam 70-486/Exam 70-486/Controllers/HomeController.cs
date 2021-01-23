using Exam_70_486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_70_486.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //public double GoldMined(double currentGold, double newlyMinedGold)
        //{
        //    double totalGold = 0.00;
        //    totalGold = currentGold + newlyMinedGold;
        //    return totalGold;
        //}

        //public ActionResult Test()
        //{
        //    double totalGold = 175.05;
        //    double newlyMinedGold = 76.03;
        //    return View();
        //}
    }
}