using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class ShiftRegistrationsController : ApiController
    {
        private Context db = new Context();

        // GET: api/ShiftRegistrations
        public IQueryable<ShiftRegistration> GetShiftRegistrations()
        {
            return db.ShiftRegistrations;
        }

        // GET: api/ShiftRegistrations/5
        [ResponseType(typeof(ShiftRegistration))]
        public IHttpActionResult GetShiftRegistration(int id)
        {
            ShiftRegistration shiftRegistration = db.ShiftRegistrations.Find(id);
            if (shiftRegistration == null)
            {
                return NotFound();
            }

            return Ok(shiftRegistration);
        }

        // PUT: api/ShiftRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShiftRegistration(int id, ShiftRegistration shiftRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shiftRegistration.Shift_Reg)
            {
                return BadRequest();
            }

            db.Entry(shiftRegistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftRegistrationExists(id))
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

        // POST: api/ShiftRegistrations
        [ResponseType(typeof(ShiftRegistration))]
        public IHttpActionResult PostShiftRegistration(ShiftRegistration shiftRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShiftRegistrations.Add(shiftRegistration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ShiftRegistrationExists(shiftRegistration.Shift_Reg))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shiftRegistration.Shift_Reg }, shiftRegistration);
        }

        // DELETE: api/ShiftRegistrations/5
        [ResponseType(typeof(ShiftRegistration))]
        public IHttpActionResult DeleteShiftRegistration(int id)
        {
            ShiftRegistration shiftRegistration = db.ShiftRegistrations.Find(id);
            if (shiftRegistration == null)
            {
                return NotFound();
            }

            db.ShiftRegistrations.Remove(shiftRegistration);
            db.SaveChanges();

            return Ok(shiftRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShiftRegistrationExists(int id)
        {
            return db.ShiftRegistrations.Count(e => e.Shift_Reg == id) > 0;
        }
    }
}