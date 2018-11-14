using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryService.Models;

namespace LibraryService.Controllers
{
    public class ReadersController : ApiController
    {
        private LibraryServiceContext db = new LibraryServiceContext();

        //GET
        public IQueryable<Reader> GetReaders()
        {
            return db.Readers;
        }

        //GET
        [ResponseType(typeof(Reader))]
        public async Task<IHttpActionResult> GetReader(int id)
        {
            Reader reader = await db.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            return Ok(reader);
        }

        //PUT
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReader(int id, Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reader.Id)
            {
                return BadRequest();
            }

            db.Entry(reader).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderExists(id))
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

        // POST: api/Readers
        [ResponseType(typeof(Reader))]
        public async Task<IHttpActionResult> PostReader(Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Readers.Add(reader);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reader.Id }, reader);
        }

        // DELETE: api/Readers/5
        [ResponseType(typeof(Reader))]
        public async Task<IHttpActionResult> DeleteReader(int id)
        {
            Reader reader = await db.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            db.Readers.Remove(reader);
            await db.SaveChangesAsync();

            return Ok(reader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReaderExists(int id)
        {
            return db.Readers.Count(e => e.Id == id) > 0;
        }
    }
}