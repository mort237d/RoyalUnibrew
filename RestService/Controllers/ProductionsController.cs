using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class ProductionsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Productions
        public IQueryable<Models.Production> GetProductions()
        {
            return db.Productions;
        }

        // GET: api/Productions/5
        [ResponseType(typeof(Models.Production))]
        public IHttpActionResult GetProduction(int id)
        {
            Models.Production production = db.Productions.Find(id);
            if (production == null)
            {
                return NotFound();
            }

            return Ok(production);
        }

        // PUT: api/Productions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduction(int id, Models.Production production)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != production.Production_ID)
            {
                return BadRequest();
            }

            db.Entry(production).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionExists(id))
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

        // POST: api/Productions
        [ResponseType(typeof(Models.Production))]
        public IHttpActionResult PostProduction(Models.Production production)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productions.Add(production);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductionExists(production.Production_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = production.Production_ID }, production);
        }

        // DELETE: api/Productions/5
        [ResponseType(typeof(Models.Production))]
        public IHttpActionResult DeleteProduction(int id)
        {
            Models.Production production = db.Productions.Find(id);
            if (production == null)
            {
                return NotFound();
            }

            db.Productions.Remove(production);
            db.SaveChanges();

            return Ok(production);
        }

        [Route("api/Productions/range/")]
        public IHttpActionResult GetRange()
        {
            string databaseName = "Production";
            string primaryKeyName = "Production_ID";
            int lastId = db.Productions.OrderByDescending(p => p.Production_ID).FirstOrDefault().Production_ID;

            string queryString = string.Format("SELECT TOP 10 * FROM {0} WHERE {1} <= {2} ORDER BY {1} DESC", databaseName, primaryKeyName, lastId);

            var reverseresult = db.Productions.SqlQuery(queryString);
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

        private bool ProductionExists(int id)
        {
            return db.Productions.Count(e => e.Production_ID == id) > 0;
        }
    }
}