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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["info"] == null)
            {
                Response.Redirect("~/user/login");
            }
            else
            {
                if (((User)Session["info"]).Role.RoleName != "Admin")
                {
                    Response.Redirect("~/user/login");
                }
            }
        }

        NajehDB db = new NajehDB();

        public ActionResult Index(int? CourseID, int? UserID, int[] UserChecked)
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email");
            if (Request.Params["btnAssign"] != null && CourseID != null)
            {
                foreach (var item in UserChecked)
                {
                    Junction junction = new Junction();
                    junction.CourseID = CourseID;
                    junction.UserID = item;
                    db.Junctions.Add(junction);
                    db.SaveChanges();
                }
            }
            
            var model = new List<User>();
            if (Request.Params["btnGetStudents"] != null)
                model = db.Users.Where(x => x.Junctions.Any(y => y.CourseID == CourseID)).ToList();

            ViewData["listCourses"] = new List<Course>();
            if (Request.Params["btnGetCourses"] != null)
                ViewData["listCourses"] = db.Courses.Where(x => x.Junctions.Any(y => y.UserID == UserID)).ToList();

            return View(model);
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