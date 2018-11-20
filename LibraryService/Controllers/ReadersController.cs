﻿using System;
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
using LibraryService.Helpers;

namespace LibraryService.Controllers
{
    public class ReadersController : ApiController
    {
        private LibraryServiceContext db = new LibraryServiceContext();

        //GET
        [Route("api/readers")]
        [HttpGet]
        public IQueryable<Reader> GetReaders()
        {
            return db.Readers;
        }

        //GET
        [Route("api/readers/{id}", Name = "GetReader")]
        [HttpGet]
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
        [Route("api/readers/signup")]
        [HttpPost]
        public async Task<IHttpActionResult> PostReader(Reader reader)
        {
            Hashing hashing = new Hashing();

            reader.Password = hashing.GenerateHash(reader.Password);
            
            db.Readers.Add(reader);
            await db.SaveChangesAsync();

            int id = reader.Id;

            return CreatedAtRoute("GetReader", new { id = reader.Id }, reader.Id);
        }
        
        [Route("api/readers/signin")]
        [HttpPost]
        public async Task<IHttpActionResult> VerifyReader(Reader reader)
        {
            Reader readerInDb = await db.Readers.FindAsync(reader.Id);

            if (readerInDb == null)
            {
                return NotFound();
            }

            Hashing hashing = new Hashing();

            if(!hashing.Verify(reader.Password, readerInDb.Password))
            {
                return NotFound();
            }

            return CreatedAtRoute("GetReader", new { id = reader.Id }, reader.Id);
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