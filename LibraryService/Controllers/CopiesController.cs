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
using Newtonsoft.Json.Linq;

namespace LibraryService.Controllers
{
    public class CopiesController : ApiController
    {
        private LibraryServiceContext db = new LibraryServiceContext();

        //GET
        public IQueryable<Copy> GetCopies()
        {
            return db.Copies;
        }

        [ResponseType(typeof(Copy))]
        public async Task<IHttpActionResult> GetCopy(int id)
        {
            Copy copy = await db.Copies.FindAsync(id);
            if (copy == null)
            {
                return NotFound();
            }

            return Ok(copy);
        }

        //PUT
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCopy(int id, Copy copy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != copy.Id)
            {
                return BadRequest();
            }

            db.Entry(copy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        [ResponseType(typeof(Copy))]
        public async Task<IHttpActionResult> PostCopy(Copy copy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Copies.Add(copy);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = copy.Id }, copy);
        }

        //DELETE
        [ResponseType(typeof(Copy))]
        public async Task<IHttpActionResult> DeleteCopy(int id)
        {
            Copy copy = await db.Copies.FindAsync(id);
            if (copy == null)
            {
                return NotFound();
            }

            db.Copies.Remove(copy);
            await db.SaveChangesAsync();

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