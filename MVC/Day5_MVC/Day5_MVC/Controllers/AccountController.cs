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
        public ActionResult Create(HttpPostedFileBase image,Account account) // URL - Form body
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
                            image.SaveAs(Server.MapPath("~/Images/" + gg + extension)); // save to images folder
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
                throw;
                //return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            var model = DB.Accounts.Find(id);
            return View(model);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase image, Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        string extension = Path.GetExtension(image.FileName);
                        var gg = Guid.NewGuid();
                        image.SaveAs(Server.MapPath("~/Images/" + gg + extension)); // save to images folder
                        account.Image = gg + extension; // save image name to DB
                    }
                    DB.Entry(account).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    Session["info"] = DB.Users.Find(account.ID);
                }
                
                return RedirectToAction("Details", new { id = account.ID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete()
        {
            var model = DB.Accounts.Find(((User)Session["info"]).ID);
            return View(model);
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ActionName("Delete")] // prevent calling the method unless the action name is "Delete"
        public ActionResult Delete(int? x) // to fulfill the overload
        {
            try
            {
                var model = DB.Accounts.Find(((User)Session["info"]).ID);
                DB.Accounts.Remove(model);
                DB.SaveChanges();

                return RedirectToAction("Details",new { ((User)Session["info"]).ID });
            }
            catch
            {
                return View();
            }
        }
    }
}
