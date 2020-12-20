using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult SendNotify()
        {
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult Manager()
        {
            return View();
        }
    }
}