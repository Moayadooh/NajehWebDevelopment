using Day5_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5_MVC.Controllers
{
    public class AccountController : Controller
    {
        NajehDB DB = new NajehDB();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["info"] == null)
                Response.Redirect("~/user/login");
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Welcom", "User");

            var model = DB.Accounts.Find(id);
            if (model == null)
                return RedirectToAction("Create");

            return View(model);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image,Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    account.ID = ((User)Session["info"]).ID;
                    if (image != null)
                    {
                        //if (image.ContentType.ToLower() == "image/jpeg")
                        //{
                            string extension = Path.GetExtension(image.FileName);
                            var gg = Guid.NewGuid();
                            image.SaveAs(Server.MapPath("/Images/" + gg + extension)); // save to images folder
                            account.Image = gg + extension; // save image name to DB
                            DB.Accounts.Add(account);
                            DB.SaveChanges();
                            return RedirectToAction("Details", new { id = account.ID });
                        //}
                        //else
                        //    ModelState.AddModelError("", "Extension file with jpeg only");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
