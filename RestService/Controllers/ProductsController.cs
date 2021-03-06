﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestService.Controllers
{
    public class ProductsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Products
        public IQueryable<Models.Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Models.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.FinishedProduct_No)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult PostProduct(Models.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.FinishedProduct_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.FinishedProduct_No }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        [Route("api/Products/range/")]
        public IHttpActionResult GetRange()
        {
            string databaseName = "Product";
            string primaryKeyName = "FinishedProduct_No";
            int lastId = db.Products.OrderByDescending(p => p.FinishedProduct_No).FirstOrDefault().FinishedProduct_No;

            string queryString = string.Format("SELECT TOP 10 * FROM {0} WHERE {1} <= {2} ORDER BY {1} DESC", databaseName, primaryKeyName, lastId);

            var reverseresult = db.Products.SqlQuery(queryString);
            var result = reverseresult.Reverse();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.FinishedProduct_No == id) > 0;
        }
    }
}