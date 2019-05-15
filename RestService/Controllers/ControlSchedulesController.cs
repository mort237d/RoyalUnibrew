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
    public class ControlSchedulesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ControlSchedules
        public IQueryable<Models.ControlSchedule> GetControlSchedules()
        {
            return db.ControlSchedules;
        }

        // GET: api/ControlSchedules/5
        [ResponseType(typeof(Models.ControlSchedule))]
        public IHttpActionResult GetControlSchedule(int id)
        {
            Models.ControlSchedule controlSchedule = db.ControlSchedules.Find(id);
            if (controlSchedule == null)
            {
                return NotFound();
            }

            return Ok(controlSchedule);
        }

        // PUT: api/ControlSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlSchedule(int id, Models.ControlSchedule controlSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlSchedule.ControlSchedule_ID)
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
        [ResponseType(typeof(Models.ControlSchedule))]
        public IHttpActionResult PostControlSchedule(Models.ControlSchedule controlSchedule)
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
                if (ControlScheduleExists(controlSchedule.ControlSchedule_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlSchedule.ControlSchedule_ID }, controlSchedule);
        }

        // DELETE: api/ControlSchedules/5
        [ResponseType(typeof(Models.ControlSchedule))]
        public IHttpActionResult DeleteControlSchedule(int id)
        {
            Models.ControlSchedule controlSchedule = db.ControlSchedules.Find(id);
            if (controlSchedule == null)
            {
                return NotFound();
            }

            db.ControlSchedules.Remove(controlSchedule);
            db.SaveChanges();

            return Ok(controlSchedule);
        }

        [Route("api/ControlSchedules/range/")]
        public IHttpActionResult GetRange()
        {
            string databaseName = "ControlSchedule";
            string primaryKeyName = "ControlSchedule_ID";
            int lastId = db.ControlSchedules.OrderByDescending(p => p.ControlSchedule_ID).FirstOrDefault().ControlSchedule_ID;

            string queryString = string.Format("SELECT TOP 10 * FROM {0} WHERE {1} <= {2} ORDER BY {1} DESC", databaseName, primaryKeyName, lastId);

            var reverseresult = db.ControlSchedules.SqlQuery(queryString);
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

        private bool ControlScheduleExists(int id)
        {
            return db.ControlSchedules.Count(e => e.ControlSchedule_ID == id) > 0;
        }
    }
}