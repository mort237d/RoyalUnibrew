using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class ControlSchedulesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ControlSchedules
        public IQueryable<ControlSchedule> GetControlSchedules()
        {
            return db.ControlSchedules;
        }

        // GET: api/ControlSchedules/5
        [ResponseType(typeof(ControlSchedule))]
        public IHttpActionResult GetControlSchedule(int id)
        {
            ControlSchedule controlSchedule = db.ControlSchedules.Find(id);
            if (controlSchedule == null)
            {
                return NotFound();
            }

            return Ok(controlSchedule);
        }

        // PUT: api/ControlSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlSchedule(int id, ControlSchedule controlSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlSchedule.Control_ID)
            {
                return BadRequest();
            }

            db.Entry(controlSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlScheduleExists(id))
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

        // POST: api/ControlSchedules
        [ResponseType(typeof(ControlSchedule))]
        public IHttpActionResult PostControlSchedule(ControlSchedule controlSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ControlSchedules.Add(controlSchedule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ControlScheduleExists(controlSchedule.Control_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlSchedule.Control_ID }, controlSchedule);
        }

        // DELETE: api/ControlSchedules/5
        [ResponseType(typeof(ControlSchedule))]
        public IHttpActionResult DeleteControlSchedule(int id)
        {
            ControlSchedule controlSchedule = db.ControlSchedules.Find(id);
            if (controlSchedule == null)
            {
                return NotFound();
            }

            db.ControlSchedules.Remove(controlSchedule);
            db.SaveChanges();

            return Ok(controlSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControlScheduleExists(int id)
        {
            return db.ControlSchedules.Count(e => e.Control_ID == id) > 0;
        }
    }
}