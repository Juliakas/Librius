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

        //POST
        [ResponseType(typeof(Reader))]
        public async Task<IHttpActionResult> PostReader(Reader reader)
        {
            db.Readers.Add(reader);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reader.Id }, reader);
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