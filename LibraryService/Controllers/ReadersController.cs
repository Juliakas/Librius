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
        public IQueryable<ReaderDTO> GetReaders()
        {
            var readers = db.Readers.Select(r => new ReaderDTO { Id = r.Id, Name = r.Name, Surname = r.Surname});

            return readers;
        }

        //GET
        [Route("api/readers/{id}", Name = "GetReader")]
        [HttpGet]
        public IHttpActionResult GetReader(int id)
        {
            var reader = db.Readers.Select(r => new ReaderDTO { Id = r.Id, Name = r.Name, Surname = r.Surname })
                .FirstOrDefault(r => r.Id == id);

            if (reader == null)
            {
                return NotFound();
            }

            return Ok(reader);
        }

        //POST
        [Route("api/readers/signup")]
        [HttpPost]
        public IHttpActionResult PostReader(Reader reader)
        {
            Hashing hashing = new Hashing();

            reader.Password = hashing.GenerateHash(reader.Password);

            Random random = new Random();
            
            reader.Email = Convert.ToString(random.Next(50));

            db.Readers.Add(reader);
            db.SaveChanges();

            int id = reader.Id;

            return CreatedAtRoute("GetReader", new { id = reader.Id }, reader.Id);
        }

        [Route("api/readers/signup/face/{reader}")]
        [HttpPost]
        public async Task<IHttpActionResult> PostReader(byte[] image, int reader)
        {
            FaceScanner scanner = new FaceScanner();
            string result = await scanner.CreatePersonAsync(Convert.ToString(reader), image);

            return Ok(result);
        }


        [Route("api/readers/signin")]
        [HttpPost]
        public IHttpActionResult VerifyReader(Reader reader)
        {
            var readerInDb = db.Readers.FirstOrDefault(i => i.Id == reader.Id);

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

        [Route("api/readers/signin/face")]
        [HttpPost]
        public async Task<IHttpActionResult> VerifyReader(byte[] image) {
            FaceScanner scanner = new FaceScanner();
            string name = await scanner.Identify(image);

            if (name.Equals(""))
            {
                return NotFound();
            }

            int readerId = Convert.ToInt32(name);

            Reader readerInDb = db.Readers.FirstOrDefault(r => r.Id == readerId);

            if(readerInDb == null)
            {
                return NotFound();
            }

            return Ok();
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