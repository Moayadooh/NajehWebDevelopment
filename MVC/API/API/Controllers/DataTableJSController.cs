using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class DataTableJSController : Controller
    {
        // GET: DataTableJS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserPartials()
        {
            return View();
        }
    }
}