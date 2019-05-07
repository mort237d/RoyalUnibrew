﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestService.Models;

namespace RestService.Controllers
{
    public class FrontpagesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Frontpages
        public IQueryable<Models.Frontpage> GetFrontpages()
        {
            return db.Frontpages;
        }

        // GET: api/Frontpages/5
        [ResponseType(typeof(Models.Frontpage))]
        public IHttpActionResult GetFrontpage(int id)
        {
            Models.Frontpage frontpage = db.Frontpages.Find(id);
            if (frontpage == null)
            {
                return NotFound();
            }

            return Ok(frontpage);
        }

        // PUT: api/Frontpages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFrontpage(int id, Models.Frontpage frontpage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frontpage.ProcessOrder_No)
            {
                return BadRequest();
            }

            db.Entry(frontpage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrontpageExists(id))
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

        // POST: api/Frontpages
        [ResponseType(typeof(Models.Frontpage))]
        public IHttpActionResult PostFrontpage(Models.Frontpage frontpage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Frontpages.Add(frontpage);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FrontpageExists(frontpage.ProcessOrder_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = frontpage.ProcessOrder_No }, frontpage);
        }

        // DELETE: api/Frontpages/5
        [ResponseType(typeof(Models.Frontpage))]
        public IHttpActionResult DeleteFrontpage(int id)
        {
            Models.Frontpage frontpage = db.Frontpages.Find(id);
            if (frontpage == null)
            {
                return NotFound();
            }

            db.Frontpages.Remove(frontpage);
            db.SaveChanges();

            return Ok(frontpage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FrontpageExists(int id)
        {
            return db.Frontpages.Count(e => e.ProcessOrder_No == id) > 0;
        }
    }
}