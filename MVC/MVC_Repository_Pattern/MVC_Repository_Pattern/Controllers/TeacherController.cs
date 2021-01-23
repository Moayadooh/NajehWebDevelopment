using MVC_Repository_Pattern.GenericRepo;
using MVC_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository_Pattern.Controllers
{
    public class TeacherController : Controller
    {
        private UserRepo userRepo = null;
        //private Repository<User> Repository = null;
        public TeacherController()
        {
            userRepo = new UserRepo();
        }

        public ActionResult index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var model = userRepo.GetLogin(email, password);
                if (model != null)
                {
                    Session["info"] = model;
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            userRepo.Insert(user);
            //userRepo.SendMail("here is body", "From@domail.com", "to@domain.com", "My Subject");
            return View();
        }
    }
}