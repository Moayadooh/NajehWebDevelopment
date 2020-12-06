using Day5_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5_MVC.Controllers
{
    public class AdminController : Controller
    {
        NajehDB db = new NajehDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRole(Guid? RoleID,int? UserID)
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email");
            if (RoleID != null)
            {
                User user = db.Users.Find(UserID);
                user.RoleRoleID = RoleID;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View(db.Users.ToList());
        }
    }
}