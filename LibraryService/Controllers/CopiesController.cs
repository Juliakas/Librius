using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryService.Helpers;
using LibraryService.Models;
using Newtonsoft.Json.Linq;

namespace LibraryService.Controllers
{
    public class CopiesController : ApiController
    {
        private LibraryServiceContext db = new LibraryServiceContext();

        //GET
        [Route("api/copies", Name = "GetCopies")]
        [HttpGet]
        public IQueryable<Copy> GetCopies()
        {
            return db.Copies;
        }

        [Route("api/copies/{id}", Name = "GetCopy")]
        [HttpGet]
        public IHttpActionResult GetCopy(int id)
        {
            var copy = db.Copies.FirstOrDefault(i => i.Id == id);
            if (copy == null)
            {
                return NotFound();
            }

            return Ok(copy);
        }

        //PUT
        [Route("api/copies/{id}")]
        [HttpPut]
        public IHttpActionResult PutCopy(int id, Copy copy)
        {
            if (id != copy.Id)
            {
                return BadRequest();
            }

            var oldCopy = db.Copies.FirstOrDefault(i => i.Id == id);
            oldCopy = copy;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CopyExists(id))
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

        //POST
        [Route("api/copies")]
        [HttpPost]
        public IHttpActionResult PostCopy(Copy copy)
        {
            db.Copies.Add(copy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtRoute("GetCopy", new { id = copy.Id }, copy.Id);
        }

        [Route("api/copies/by-barcode/{reader}")]
        [HttpPost]
        public IHttpActionResult PostCopy(byte[] image, int reader)
        {
            string result = BarcodeScanner.Scan(image);

            if (result.Equals(""))
            {
                return NotFound();
            }

            int id = Convert.ToInt32(result);
            Copy copy = db.Copies.FirstOrDefault(c => c.Id == id);

            if (copy._reader != null)
            {
                return Conflict();
            }

            copy._reader = db.Readers.FirstOrDefault(r => r.Id == reader);
            db.SaveChanges();
            return Ok(result);
        }

        //DELETE
        [Route("api/copies/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCopy(int id)
        {
            Copy copy = db.Copies.FirstOrDefault(i => i.Id == id);

            if (copy == null)
            {
                return NotFound();
            }

            db.Copies.Remove(copy);
            db.SaveChanges();

            return Ok(copy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CopyExists(int id)
        {
            return db.Copies.Count(e => e.Id == id) > 0;
        }
    }
}
