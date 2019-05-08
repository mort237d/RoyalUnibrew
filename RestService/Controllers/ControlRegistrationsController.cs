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
    public class ControlRegistrationsController : ApiController
    {
        private Context db = new Context();

        // GET: api/ControlRegistrations
        public IQueryable<Models.ControlRegistration> GetControlRegistrations()
        {
            return db.ControlRegistrations;
        }

        // GET: api/ControlRegistrations/5
        [ResponseType(typeof(Models.ControlRegistration))]
        public IHttpActionResult GetControlRegistration(int id)
        {
            Models.ControlRegistration controlRegistration = db.ControlRegistrations.Find(id);
            if (controlRegistration == null)
            {
                return NotFound();
            }

            return Ok(controlRegistration);
        }

        // PUT: api/ControlRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlRegistration(int id, Models.ControlRegistration controlRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlRegistration.ControlRegistration_ID)
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
        [ResponseType(typeof(Models.ControlRegistration))]
        public IHttpActionResult PostControlRegistration(Models.ControlRegistration controlRegistration)
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
                if (ControlRegistrationExists(controlRegistration.ControlRegistration_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlRegistration.ControlRegistration_ID }, controlRegistration);
        }

        // DELETE: api/ControlRegistrations/5
        [ResponseType(typeof(Models.ControlRegistration))]
        public IHttpActionResult DeleteControlRegistration(int id)
        {
            Models.ControlRegistration controlRegistration = db.ControlRegistrations.Find(id);
            if (controlRegistration == null)
            {
                return NotFound();
            }

            db.ControlRegistrations.Remove(controlRegistration);
            db.SaveChanges();

            return Ok(controlRegistration);
        }

        [Route("api/ControlRegistrations/range/{offset}")]
        public IHttpActionResult GetRange(int offset)
        {
            ObservableCollection<ControlRegistration> list = new ObservableCollection<ControlRegistration>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(db.ControlRegistrations.Find(offset + i));
            }
            return Ok(list);
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
            return db.ControlRegistrations.Count(e => e.ControlRegistration_ID == id) > 0;
        }
    }
}