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
    public class BooksController : ApiController
    {
        private LibraryServiceContext db = new LibraryServiceContext();

        //GET
        [Route("api/books")]
        [HttpGet]
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        [Route("api/Books/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBook(string id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }



        //PUT
        [Route("api/books/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutBook(string id, Book book)
        {
            if (id != book.Isbn)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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
        [Route("api/books")]
        [HttpPost]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            db.Books.Add(book);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.Isbn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = book.Isbn }, book.Isbn);
        }

        //DELETE
        [Route("api/books/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBook(string id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(string id)
        {
            return db.Books.Count(e => e.Isbn == id) > 0;
        }
    }
}