using Day5_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5_MVC.Controllers
{
    public class StudentController : Controller
    {
        NajehDB db = new NajehDB();

        // will be [HttpGet] and [HttpPost]
        public ActionResult Assign(int? DDLMajors)
        {
            ViewBag.DDLMajors = new SelectList(db.Majors, "ID", "Title"); //Drop Down List
            var model = db.Users.Find(((User)Session["info"]).ID);
            if (DDLMajors != null)
            {
                model.MajorID = DDLMajors;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return View(model);
        }

        public ActionResult GetStudentMajors(int? MjrID)
        {
            ViewBag.MjrID = new SelectList(db.Majors, "ID", "Title"); //Drop Down List
            var model = new List<User>(); // Empty User List
            if (MjrID != null)
                model = db.Users.Where(x => x.MajorID == MjrID).ToList();

            return View(model);
        }
    }
}