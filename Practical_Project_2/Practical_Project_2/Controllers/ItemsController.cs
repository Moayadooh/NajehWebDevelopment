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
using Practical_Project_2.Models;

namespace Practical_Project_2.Controllers
{
    public class ItemsController : ApiController
    {
        private ShoppingDB db = new ShoppingDB("");

        // (GET request)
        // get items based on selected category, items per page and page number(pagination)
        [Route("api/Items/{categoryID}/{itemsPerPage}/{pageNum}")]
        public IQueryable<Item> GetItems(int categoryID, int itemsPerPage, int pageNum)
        {
            if (itemsPerPage == -1)
                return db.Items.Where(x => x.CategoryID == categoryID); // get all items
            else
            {
                int itemsToSkip = pageNum * itemsPerPage - itemsPerPage;
                var list = db.Items.Where(x => x.CategoryID == categoryID).ToList();
                return list.Skip(itemsToSkip).Take(itemsPerPage).AsQueryable();
            }
        }

        // (GET request)
        // get number of item based on category 
        [Route("api/Items/{categoryID}")]
        public int GetNumOfItems(int categoryID)
        {
            return db.Items.Where(x => x.CategoryID == categoryID).Count();
        }

        // (GET request)
        // get all categories
        [Route("api/Items")]
        public IQueryable<Category> GetCategories()
        {
            var model = db.Items.Include(x => x.Category);
            return model.Select(x => x.Category).Distinct();
        }

        // (GET request)
        // get item based on id
        [ResponseType(typeof(Item))] //return 404 if error is occur
        [Route("api/GetItem/{id}")]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // (PUT request)
        // update item based on id
        [ResponseType(typeof(void))]
        [Route("api/UpdateItem/{id}")]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.ID)
                return BadRequest();
            db.Entry(item).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                    return NotFound();
                else
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // (POST request)
        // add item
        [ResponseType(typeof(Item))]
        [Route("api/AddItem")]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Items.Add(item);
            db.SaveChanges();
            return Ok(item);
            //return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        }

        // (DELETE request)
        // delete item based on id
        [ResponseType(typeof(Item))]
        [Route("api/DeleteItem/{id}")]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
                return NotFound();
            db.Items.Remove(item);
            db.SaveChanges();
            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ID == id) > 0;
        }
    }
}