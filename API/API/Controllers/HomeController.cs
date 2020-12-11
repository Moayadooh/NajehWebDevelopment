using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SaveLanguageToCookies(string lang)
        {
            // To save prefer language on Web Browser e.g Chrome, IE, Firefox
            if (lang != null)
            {
                HttpCookie ck = new HttpCookie("currentlang");
                ck.Value = lang;
                ck.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("index", "Home");
        }
    }
}