using MVC_Payment.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Payment.Controllers
{
    public class HomeController : Controller
    {
        private TVDB db = new TVDB();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Redirect()
        {
            return View();
        }

        //https://localhost:44344/Home/GetData
        public JsonResult GetData()
        {
            return Json(db.Employee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateOrder()
        {
            var client = new RestClient("https://api.tap.company/v2/orders");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            //request.AddParameter("application/json", "{\"amount\":1,\"currency\":\"KWD\",\"customer\":{\"first_name\":\"test\",\"middle_name\":\"\",\"last_name\":\"test\",\"phone\":{\"country_code\":\"965\",\"number\":\"51234567\"},\"email\":\"testcgara@test.com\"},\"items\":[{\"name\":{\"en\":\"test\"},\"description\":{\"en\":\"test\"},\"image\":\"\",\"currency\":\"KWD\",\"amount\":1,\"quantity\":\"1\",\"discount\":{\"type\":\"P\",\"value\":0}}],\"tax\":[{\"description\":\"test\",\"name\":\"VAT\",\"rate\":{\"type\":\"F\",\"value\":1}}],\"shipping\":{\"amount\":1,\"currency\":\"KWD\",\"description\":{\"en\":\"test\"},\"address\":{\"recipient_name\":\"test\",\"line1\":\"sdfghjk\",\"line2\":\"oiuytr\",\"district\":\"hawally\",\"city\":\"hawally\",\"state\":\"hw\",\"zip_code\":\"30003\",\"po_box\":\"200021\",\"country\":\"kuwait\"}},\"metadata\":{\"udf1\":\"\",\"udf2\":\"\"},\"reference\":{\"invoice\":\"\",\"order\":\"\"}}", ParameterType.RequestBody);
            request.AddParameter("application/json", GetData(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return View();
        }
    }
}