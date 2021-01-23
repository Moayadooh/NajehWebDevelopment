using EyadConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EyadConsumer.Controllers
{
    public class HomeController : Controller
    {
        private TVDB db = new TVDB();
        ThawaniService.WebService1SoapClient obj = new ThawaniService.WebService1SoapClient();

        public JsonResult GetData()
        {
            return Json(db.Employee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateOrder()
        {
            obj.GetOrder(GetData(), "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            return View();
        }
    }
}