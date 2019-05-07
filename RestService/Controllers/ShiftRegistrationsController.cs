﻿using System.Data.Entity;
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
        public IQueryable<Models.ShiftRegistration> GetShiftRegistrations()
        {
            return db.ShiftRegistrations;
        }

        // GET: api/ShiftRegistrations/5
        [ResponseType(typeof(Models.ShiftRegistration))]
        public IHttpActionResult GetShiftRegistration(int id)
        {
            Models.ShiftRegistration shiftRegistration = db.ShiftRegistrations.Find(id);
            if (shiftRegistration == null)
            {
                return NotFound();
            }

            return Ok(shiftRegistration);
        }

        // PUT: api/ShiftRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShiftRegistration(int id, Models.ShiftRegistration shiftRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shiftRegistration.ShiftRegistration_ID)
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
        [ResponseType(typeof(Models.ShiftRegistration))]
        public IHttpActionResult PostShiftRegistration(Models.ShiftRegistration shiftRegistration)
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
                if (ShiftRegistrationExists(shiftRegistration.ShiftRegistration_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shiftRegistration.ShiftRegistration_ID }, shiftRegistration);
        }

        // DELETE: api/ShiftRegistrations/5
        [ResponseType(typeof(Models.ShiftRegistration))]
        public IHttpActionResult DeleteShiftRegistration(int id)
        {
            Models.ShiftRegistration shiftRegistration = db.ShiftRegistrations.Find(id);
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
            return db.ShiftRegistrations.Count(e => e.ShiftRegistration_ID == id) > 0;
        }
    }
}