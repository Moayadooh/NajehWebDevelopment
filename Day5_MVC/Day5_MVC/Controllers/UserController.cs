using Day5_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5_MVC.Controllers
{
    public class UserController : Controller
    {
        NajehDB DB = new NajehDB();

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["info"] != null)
                return RedirectToAction("Welcome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid) // check all fields validations
                {
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    return RedirectToAction("Login");

                    //if (!IsUserExist(user.Email))
                    //{
                    //    DB.Users.Add(user);
                    //    DB.SaveChanges();
                    //    return RedirectToAction("Login");
                    //}
                    //else
                    //    ModelState.AddModelError("", "Email is already taken, try another one!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Email is already taken, try another one!");
            }
            return View();
        }

        //public bool IsUserExist(string email)
        //{
        //    return DB.Users.Count(x => x.Email == email) > 0;
        //}

        //[HttpGet] no need to type [HttpGet] if [HttpPost] is there or vice versa
        public ActionResult Login()
        {
            if (Session["info"] != null)
                return RedirectToAction("Welcome");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            //if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            //{
                var model = DB.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (model == null)
                    ViewBag.errmsg = "Please Verify Email and Password";
                else
                {
                    Session["info"] = user.Email;
                    return RedirectToAction("Welcome");
                }
            //}
            return View();
        }

        public ActionResult Welcome()
        {
            //if (Session["info"] == null)
            //    return RedirectToAction("Login");
            return View();
        }

        public ActionResult Logout()
        {
            Session["info"] = null;
            return RedirectToAction("Login");
        }
    }
}