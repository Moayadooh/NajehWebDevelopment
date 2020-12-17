using MVC_Repository_Pattern.GenericRepo;
using MVC_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository_Pattern.Controllers
{
    public class StudentController : Controller
    {
        private IRepository<User> Repository = null; // Add header function only to user class
        public StudentController()
        {
            Repository = new Repository<User>(); // implement body of headers code e.g add, delete..etc
        }

        public ActionResult Index()
        {
            return View(Repository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(Repository.GetByID(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            Repository.Add(user);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Repository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            Repository.Update(user);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Repository.GetByID(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(User user)
        {
            Repository.Delete(user.ID);
            return RedirectToAction("index");
        }
    }
}