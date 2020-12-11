using MVC_DB_First.Models;
using MVC_DB_First.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DB_First.Controllers
{
    public class HomeController : Controller
    {
        restatedbEntities db = new restatedbEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                // 1- call sps
                //db.Users.SqlQuery("dbo.sp_InsertUser", new SqlParameter("@Email", user.Email),
                //    new SqlParameter("@Email", user.Email),
                //    new SqlParameter("@Password", user.Password),
                //    new SqlParameter("@Confirm", user.RetypePassword)
                //    );

                //2- call sps
                //db.Database.SqlQuery<User>("dbo.sp_InsertUser", new SqlParameter("@Email", user.Email),
                //    new SqlParameter("@Email", user.Email),
                //    new SqlParameter("@Password", user.Password),
                //    new SqlParameter("@Confirm", user.RetypePassword)
                //
                //3- call sps or sql command
                //db.Database.ExecuteSqlCommand("select password from Users");

                long r = db.sp_InsertUser(user.Name, user.Email, MiscCode.PassHasher(user.Password), MiscCode.PassHasher(user.RetypePassword));
                if (r > 0)
                    return RedirectToAction("login", "Home");
                else
                    ModelState.AddModelError("", "Please verify your data!!");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var pass = MiscCode.PassHasher(user.Password);
                var model = db.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == pass);
                if (model != null)
                {
                    Session["info"] = model;
                    return RedirectToAction("index");
                }
                else
                    ModelState.AddModelError("", "Please verify Email or password");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["info"] = null;
            return RedirectToAction("login", "Home");
        }
    }
}