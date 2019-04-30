using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class TUsController : ApiController
    {
        private Context db = new Context();

        // GET: api/TUs
        public IQueryable<TU> GetTUs()
        {
            return db.TUs;
        }

        // GET: api/TUs/5
        [ResponseType(typeof(TU))]
        public IHttpActionResult GetTU(int id)
        {
            TU tU = db.TUs.Find(id);
            if (tU == null)
            {
                return NotFound();
            }

            return Ok(tU);
        }

        // PUT: api/TUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTU(int id, TU tU)
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
        [ResponseType(typeof(TU))]
        public IHttpActionResult PostTU(TU tU)
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
        [ResponseType(typeof(TU))]
        public IHttpActionResult DeleteTU(int id)
        {
            TU tU = db.TUs.Find(id);
            if (tU == null)
            {
                return NotFound();
            }

            db.TUs.Remove(tU);
            db.SaveChanges();

            return Ok(tU);
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