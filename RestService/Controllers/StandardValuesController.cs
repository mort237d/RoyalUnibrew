using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestService;
using RestService.Models;

namespace RestService.Controllers
{
    public class StandardValuesController : ApiController
    {
        private Context db = new Context();

        // GET: api/StandardValues
        public IQueryable<Models.StandardValue> GetStandardValues()
        {
            return db.StandardValues;
        }

        // GET: api/StandardValues/5
        [ResponseType(typeof(Models.StandardValue))]
        public IHttpActionResult GetStandardValue(string id)
        {
            Models.StandardValue standardValue = db.StandardValues.Find(id);
            if (standardValue == null)
            {
                return NotFound();
            }

            return Ok(standardValue);
        }

        // PUT: api/StandardValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStandardValue(string id, Models.StandardValue standardValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standardValue.Name)
            {
                return BadRequest();
            }

            db.Entry(standardValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardValueExists(id))
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

        // POST: api/StandardValues
        [ResponseType(typeof(Models.StandardValue))]
        public IHttpActionResult PostStandardValue(Models.StandardValue standardValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StandardValues.Add(standardValue);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StandardValueExists(standardValue.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = standardValue.Name }, standardValue);
        }

        // DELETE: api/StandardValues/5
        [ResponseType(typeof(Models.StandardValue))]
        public IHttpActionResult DeleteStandardValue(string id)
        {
            Models.StandardValue standardValue = db.StandardValues.Find(id);
            if (standardValue == null)
            {
                return NotFound();
            }

            db.StandardValues.Remove(standardValue);
            db.SaveChanges();

            return Ok(standardValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StandardValueExists(string id)
        {
            return db.StandardValues.Count(e => e.Name == id) > 0;
        }
    }
}