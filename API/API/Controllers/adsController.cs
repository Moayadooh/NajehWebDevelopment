using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class adsController : ApiController
    {
        private TVDB db = new TVDB();

        // GET: api/ads
        public IQueryable<ads> Getads()
        {
            return db.ads;
        }

        // GET: api/ads/5
        [ResponseType(typeof(ads))]
        public IHttpActionResult Getads(int id)
        {
            ads ads = db.ads.Find(id);
            if (ads == null)
            {
                return NotFound();
            }

            return Ok(ads);
        }

        // PUT: api/ads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putads(int id, ads ads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ads.ID)
            {
                return BadRequest();
            }

            db.Entry(ads).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ads
        [ResponseType(typeof(ads))]
        public IHttpActionResult Postads(ads ads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ads.Add(ads);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ads.ID }, ads);
        }

        // DELETE: api/ads/5
        [ResponseType(typeof(ads))]
        public IHttpActionResult Deleteads(int id)
        {
            ads ads = db.ads.Find(id);
            if (ads == null)
            {
                return NotFound();
            }

            db.ads.Remove(ads);
            db.SaveChanges();

            return Ok(ads);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool adsExists(int id)
        {
            return db.ads.Count(e => e.ID == id) > 0;
        }
    }
}