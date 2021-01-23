using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class UserController : Controller
    {
        TVDB db = new TVDB();
        // GET: User
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ads ads)
        {
            if (ModelState.IsValid)
            {
                db.ads.Add(ads);
                db.SaveChanges();
            }
            return RedirectToAction("Userpartials", "dataTableJS");
        }

        public ActionResult Display()
        {
            return PartialView(db.ads.ToList());
        }

        public ActionResult GetAngularApi()
        {
            return View();
        }
    }
}