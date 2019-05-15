using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestService.Controllers
{
    public class TUsController : ApiController
    {
        private Context db = new Context();

        // GET: api/TUs
        public IQueryable<Models.TU> GetTUs()
        {
            return db.TUs;
        }

        // GET: api/TUs/5
        [ResponseType(typeof(Models.TU))]
        public IHttpActionResult GetTU(int id)
        {
            Models.TU tU = db.TUs.Find(id);
            if (tU == null)
            {
                return NotFound();
            }

            return Ok(tU);
        }

        // PUT: api/TUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTU(int id, Models.TU tU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tU.TU_ID)
            {
                return BadRequest();
            }

            db.Entry(tU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TUExists(id))
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

        // POST: api/TUs
        [ResponseType(typeof(Models.TU))]
        public IHttpActionResult PostTU(Models.TU tU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TUs.Add(tU);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TUExists(tU.TU_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tU.TU_ID }, tU);
        }

        // DELETE: api/TUs/5
        [ResponseType(typeof(Models.TU))]
        public IHttpActionResult DeleteTU(int id)
        {
            Models.TU tU = db.TUs.Find(id);
            if (tU == null)
            {
                return NotFound();
            }

            db.TUs.Remove(tU);
            db.SaveChanges();

            return Ok(tU);
        }

        [Route("api/TUs/range/")]
        public IHttpActionResult GetRange()
        {
            string databaseName = "TU";
            string primaryKeyName = "TU_ID";
            int lastId = db.TUs.OrderByDescending(p => p.TU_ID).FirstOrDefault().TU_ID;

            string queryString = string.Format("SELECT TOP 10 * FROM {0} WHERE {1} <= {2} ORDER BY {1} DESC", databaseName, primaryKeyName, lastId);

            var reverseresult = db.TUs.SqlQuery(queryString);
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

        private bool TUExists(int id)
        {
            return db.TUs.Count(e => e.TU_ID == id) > 0;
        }
    }
}