using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class ControlRegistrationsController : ApiController
    {
        private Context db = new Context();

        // GET: api/ControlRegistrations
        public IQueryable<ControlRegistration> GetControlRegistrations()
        {
            return db.ControlRegistrations;
        }

        // GET: api/ControlRegistrations/5
        [ResponseType(typeof(ControlRegistration))]
        public IHttpActionResult GetControlRegistration(int id)
        {
            ControlRegistration controlRegistration = db.ControlRegistrations.Find(id);
            if (controlRegistration == null)
            {
                return NotFound();
            }

            return Ok(controlRegistration);
        }

        // PUT: api/ControlRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlRegistration(int id, ControlRegistration controlRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlRegistration.LabelControl_ID)
            {
                return BadRequest();
            }

            db.Entry(controlRegistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlRegistrationExists(id))
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

        // POST: api/ControlRegistrations
        [ResponseType(typeof(ControlRegistration))]
        public IHttpActionResult PostControlRegistration(ControlRegistration controlRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ControlRegistrations.Add(controlRegistration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ControlRegistrationExists(controlRegistration.LabelControl_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlRegistration.LabelControl_ID }, controlRegistration);
        }

        // DELETE: api/ControlRegistrations/5
        [ResponseType(typeof(ControlRegistration))]
        public IHttpActionResult DeleteControlRegistration(int id)
        {
            ControlRegistration controlRegistration = db.ControlRegistrations.Find(id);
            if (controlRegistration == null)
            {
                return NotFound();
            }

            db.ControlRegistrations.Remove(controlRegistration);
            db.SaveChanges();

            return Ok(controlRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControlRegistrationExists(int id)
        {
            return db.ControlRegistrations.Count(e => e.LabelControl_ID == id) > 0;
        }
    }
}