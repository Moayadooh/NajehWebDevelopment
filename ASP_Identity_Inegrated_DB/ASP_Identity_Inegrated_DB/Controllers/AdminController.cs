using ASP_Identity_Inegrated_DB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Identity_Inegrated_DB.Controllers
{
    public class AdminController : Controller
    {
        echodb db = new echodb();

        public AdminController()
        {
            db = new echodb();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public List<ApplicationUser> model = null;

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection rolename)
        {
            try
            {
                db.Roles.Add(new IdentityRole(rolename["txtRoleName"]));
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Role Already Exist");
            }
            return View();
        }

        public ActionResult ManagerRole(string RoleID, string UserID)
        {

            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name"); // DDL
            ViewBag.UserID = new SelectList(UserManager.Users, "ID", "Email"); // DDL

            model = UserManager.Users.ToList();
            if (!string.IsNullOrEmpty(RoleID))
            {
                var modelrole = UserManager.Users.Select(x => x.Roles.Any(y => y.RoleId != null));
                model = model.Where(x => x.Roles.Any(y => y.RoleId == RoleID)).ToList();
            }

            if (Request.Params["btnAssignRole"] != null)
            {
                if (!string.IsNullOrEmpty(RoleID) && !string.IsNullOrEmpty(UserID))
                {
                    UserManager.AddToRole(UserID, ((SelectList)ViewBag.RoleID).Single(x => x.Value == RoleID).Text);
                    ViewBag.Result = "Role has been Assigned";
                }
            }
            return View(model);
        }
    }
}