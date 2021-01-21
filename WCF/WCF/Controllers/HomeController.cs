using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfServiceNewsOM;

namespace WCF.Controllers
{
    public class HomeController : Controller
    {
        Service1 srv = new Service1();

        // GET: Home
        public ActionResult Index()
        {
            return View(srv.GetAllNews());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(News news)
        {
            try
            {
                srv.AddNews(news);
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}
