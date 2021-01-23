using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day4_MVC.Models;

namespace Day4_MVC.Controllers
{
    public class CarsController : Controller
    {
        private CarDB db = new CarDB();

        // GET: Cars
        public ActionResult Index(string brand,string country,string DateRelease)
        {
            var model = db.Cars.ToList();

            //Drop Down List Data
            var listCountry = model.Select(x => x.Country).Distinct();
            ViewBag.country = new SelectList(listCountry); //ViewBag.country refer to the property name in HTML

            //Filters
            if (!string.IsNullOrEmpty(brand))
                model = model.Where(x => x.Brand.ToLower().Contains(brand.ToLower())).ToList();
            if (!string.IsNullOrEmpty(country))
                model = model.Where(x => x.Country == country).ToList();
            if (!string.IsNullOrEmpty(DateRelease))
            {
                var date = DateTime.Parse(DateRelease);
                model = model.Where(x => x.DateRelease.Year == date.Year).ToList();
            }

            return View(model);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            //Drop Down List Data
            var listCountry = db.Cars.Select(x => x.Country).Distinct();
            ViewBag.country = new SelectList(listCountry);

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brand,Country,DateRelease,Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            //Drop Down List Data
            var listCountry = db.Cars.Select(x => x.Country).Distinct();
            ViewBag.country = new SelectList(listCountry);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,Country,DateRelease,Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
