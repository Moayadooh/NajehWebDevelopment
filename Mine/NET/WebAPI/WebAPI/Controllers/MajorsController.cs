using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "https://localhost:44347", headers: "*", methods: "*")]
    public class MajorsController : ApiController
    {
        private MajorDB db = new MajorDB();

        // GET: api/Majors
        public IQueryable<Major> GetMajors()
        {
            return db.Majors;
        }

        // GET: api/Majors/5
        [ResponseType(typeof(Major))]
        public IHttpActionResult GetMajor(int id)
        {
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        // PUT: api/Majors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajor(int id, Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != major.ID)
            {
                return BadRequest();
            }

            db.Entry(major).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/Majors
        [ResponseType(typeof(Major))]
        public IHttpActionResult PostMajor(Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majors.Add(major);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = major.ID }, major);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Majors/5
        [ResponseType(typeof(Major))]
        public IHttpActionResult DeleteMajor(int id)
        {
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return NotFound();
            }

            db.Majors.Remove(major);
            db.SaveChanges();

            //return Ok(major);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajorExists(int id)
        {
            return db.Majors.Count(e => e.ID == id) > 0;
        }
    }
}