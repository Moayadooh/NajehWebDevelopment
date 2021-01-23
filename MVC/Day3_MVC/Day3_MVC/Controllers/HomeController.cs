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
            GetMapPath();
            var model = companyDB.Employees.ToList();
            return View(model);
        }

        public ActionResult Search(string fname)
        {
            GetMapPath();
            var model = companyDB.Employees.ToList();
            if (!string.IsNullOrEmpty(fname))
                model = model.Where(x => x.Name.ToLower().Contains(fname.ToLower())).ToList();
            return View(model);
        }

        public ActionResult Contact()
        {
            GetMapPath();
            return View();
        }

        public void GetMapPath()
        {
            ViewBag.controller = RouteData.Values["Controller"];
            ViewBag.action = RouteData.Values["Action"];
            ViewBag.id = RouteData.Values["id"];
        }
    }
}