using Practical_Project_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_Project_2.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["role"] == null || (string)Session["role"] != "Admin")
                Response.Redirect("~/Home/Login");
        }

        private ShoppingDB db = new ShoppingDB();

        public ActionResult Index()
        {
            ViewBag.CategoryDDL = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        public ActionResult UsersDetails()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UploadImage()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    string fileName = "";
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "images/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                            fname = file.FileName;

                        var gg = Guid.NewGuid();
                        fileName = gg + "__" + fname;
                        fname = Path.Combine(Server.MapPath("~/images/"), fileName);
                        file.SaveAs(fname);
                    }
                    //return Json("File Uploaded Successfully!");
                    return Json(fileName);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No file selected.");
            }
        }
    }
}