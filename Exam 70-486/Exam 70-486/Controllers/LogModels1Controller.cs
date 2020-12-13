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
using Exam_70_486.Models;

namespace Exam_70_486.Controllers
{
    public class LogModels1Controller : ApiController
    {
        private MyDB db = new MyDB();

        // GET: api/LogModels1
        public IQueryable<LogModel> GetLogModels()
        {
            return db.LogModels;
        }

        // GET: api/LogModels1/5
        [ResponseType(typeof(LogModel))]
        public IHttpActionResult GetLogModel(int id)
        {
            LogModel logModel = db.LogModels.Find(id);
            if (logModel == null)
            {
                return NotFound();
            }

            return Ok(logModel);
        }

        // PUT: api/LogModels1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogModel(int id, LogModel logModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logModel.ID)
            {
                return BadRequest();
            }

            db.Entry(logModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogModelExists(id))
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

        // POST: api/LogModels1
        [ResponseType(typeof(LogModel))]
        public IHttpActionResult PostLogModel(LogModel logModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogModels.Add(logModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = logModel.ID }, logModel);
        }

        // DELETE: api/LogModels1/5
        [ResponseType(typeof(LogModel))]
        public IHttpActionResult DeleteLogModel(int id)
        {
            LogModel logModel = db.LogModels.Find(id);
            if (logModel == null)
            {
                return NotFound();
            }

            db.LogModels.Remove(logModel);
            db.SaveChanges();

            return Ok(logModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogModelExists(int id)
        {
            return db.LogModels.Count(e => e.ID == id) > 0;
        }
    }
}