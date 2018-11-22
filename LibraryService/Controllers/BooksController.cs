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
        public IHttpActionResult GetBook(string id)
        {
            var book = db.Books.FirstOrDefault(i => i.Isbn == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }



        //PUT
        [Route("api/books/{id}")]
        [HttpPut]
        public IHttpActionResult PutBook(string id, Book book)
        {
            if (id != book.Isbn)
            {
                return BadRequest();
            }

            var oldBook = db.Books.FirstOrDefault(i => i.Isbn == id);

            oldBook = book;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostBook(Book book)
        {
            db.Books.Add(book);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult DeleteBook(string id)
        {
            var book = db.Books.FirstOrDefault(i => i.Isbn == id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

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