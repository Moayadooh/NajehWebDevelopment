using Day3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day3_MVC.Controllers
{
    public class HomeController : Controller
    {
        CompanyDB companyDB = new CompanyDB();
        public ActionResult Index()
        {
            var model = companyDB.Employees.ToList();
            return View(model);
        }
    }
}