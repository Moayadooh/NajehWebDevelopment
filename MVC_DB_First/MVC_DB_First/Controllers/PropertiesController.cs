using MVC_DB_First.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DB_First.Controllers
{
    public class PropertiesController : Controller
    {
        restatedbEntities db = new restatedbEntities();

        // GET: Properties
        [HttpGet]
        public ActionResult Gallery()
        {
            int? sessionid = null;
            ViewBag.Typeid = new SelectList(db.Types, "TypeID", "Name");

            var model = db.Images.ToList();
            if (Session["info"] != null)
            {
                sessionid = ((User)Session["info"]).ID;
                model = model.Where(x => x.Property.UserID == sessionid).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Gallery(HttpPostedFileBase ImageName, Property prop)
        {
            prop.PropertyID = Guid.NewGuid();
            prop.Status = "ForSale";
            ViewBag.Typeid = new SelectList(db.Types, "TypeID", "Name", prop.Typeid); // save value of typeid from dropdownlist to database table field "typeid"
            db.Properties.Add(prop);
            db.SaveChanges();

            if (ImageName != null)
            {
                BinaryReader br = new BinaryReader(ImageName.InputStream);
                var readerbytes = br.ReadBytes(ImageName.ContentLength);
                Image img = new Image();
                img.ImageName = readerbytes;
                img.propertyid = prop.PropertyID;
                img.ImageType = ImageName.ContentType;
                db.Images.Add(img);
                db.SaveChanges();

            }
            //db.sp_InsertProperty(Guid.NewGuid(), "", 1, 1.2, 3, 4);
            return RedirectToAction("Gallery");
        }

        public FileContentResult GetImage(int id) //https://localhost:44388/Properties/GetImage/1025
        {
            var propimg = db.Images.Find(id);
            if (propimg != null)
            {
                return File(propimg.ImageName, propimg.ImageType);
            }
            else
            {
                return null;
            }
        }
    }
}