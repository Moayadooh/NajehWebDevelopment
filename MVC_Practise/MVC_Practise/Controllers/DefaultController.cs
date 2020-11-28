using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Practise.Models;

namespace MVC_Practise.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        CollegeDB DB = new CollegeDB();
        public ActionResult Index()
        {
            GetMapPath();
            return View(DB.Students.ToList());
        }

        public ActionResult Search(float? Score)
        {
            GetMapPath();
            var model = DB.Students.ToList();
            if (Score != null)
                model = model.Where(x => x.Score >= Score).ToList();
            return View(model);
        }

        public void GetMapPath()
        {
            ViewBag.controller = RouteData.Values["Controller"];
            ViewBag.action = RouteData.Values["Action"];
            ViewBag.id = RouteData.Values["id"];
        }
    }
}