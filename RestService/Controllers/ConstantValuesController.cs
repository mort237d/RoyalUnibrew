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
    public class ConstantValuesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ConstantValues
        public IQueryable<Models.ConstantValue> GetConstantValues()
        {
            return db.ConstantValues;
        }

        // GET: api/ConstantValues/5
        [ResponseType(typeof(Models.ConstantValue))]
        public IHttpActionResult GetConstantValue(string id)
        {
            Models.ConstantValue constantValue = db.ConstantValues.Find(id);
            if (constantValue == null)
            {
                return NotFound();
            }

            return Ok(constantValue);
        }

        // PUT: api/ConstantValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConstantValue(string id, Models.ConstantValue constantValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != constantValue.Name)
            {
                return BadRequest();
            }

            db.Entry(constantValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstantValueExists(id))
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

        // POST: api/ConstantValues
        [ResponseType(typeof(Models.ConstantValue))]
        public IHttpActionResult PostConstantValue(Models.ConstantValue constantValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConstantValues.Add(constantValue);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConstantValueExists(constantValue.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = constantValue.Name }, constantValue);
        }

        // DELETE: api/ConstantValues/5
        [ResponseType(typeof(Models.ConstantValue))]
        public IHttpActionResult DeleteConstantValue(string id)
        {
            Models.ConstantValue constantValue = db.ConstantValues.Find(id);
            if (constantValue == null)
            {
                return NotFound();
            }

            db.ConstantValues.Remove(constantValue);
            db.SaveChanges();

            return Ok(constantValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConstantValueExists(string id)
        {
            return db.ConstantValues.Count(e => e.Name == id) > 0;
        }
    }
}