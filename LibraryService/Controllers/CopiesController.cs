using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            SqlCommand selectComm = new SqlCommand("SELECT ID, Reader, ISBN, Borrowed FROM dbo.Copies WHERE Id = @Id", (SqlConnection)db.Database.Connection);
            SqlCommand updateComm = new SqlCommand("UPDATE dbo.Copies SET Reader = @Reader WHERE Id = @Id", (SqlConnection)db.Database.Connection);

            selectComm.Parameters.AddWithValue("@Id", id);

            updateComm.Parameters.AddWithValue("@Reader", copy.Reader);
            updateComm.Parameters.AddWithValue("@Id", copy.Id);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = selectComm;
            da.UpdateCommand = updateComm;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Rows[0]["Reader"] = copy.Reader;

            da.Update(dt);

            da.Dispose();

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

        [Route("api/copies/by-barcode")]
        [HttpPost]
        public IHttpActionResult PostCopy(byte[] image)
        {
            string result = BarcodeScanner.Scan(image);

            if (result.Equals(""))
            {
                return NotFound();
            }

            int id = Convert.ToInt32(result);
            Copy copy = db.Copies.FirstOrDefault(c => c.Id == id);

            if(copy == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //DELETE
        [Route("api/copies/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCopy(int id)
        {
            /*Copy copy = db.Copies.FirstOrDefault(i => i.Id == id);

            if (copy == null)
            {
                return NotFound();
            }

            db.Copies.Remove(copy);
            db.SaveChanges();
            */

            SqlCommand deleteComm = new SqlCommand("DELETE FROM dbo.Copies WHERE Id = @Id", (SqlConnection) db.Database.Connection);
            deleteComm.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 50, "Id"));

            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Reader, ISBN, Borrowed FROM dbo.Copies", (SqlConnection)db.Database.Connection);

            da.DeleteCommand = deleteComm;

            DataTable dt = new DataTable();

            da.Fill(dt);

            dt.Rows[0].Delete();

            da.Update(dt);
            da.Dispose();

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

        private bool CopyExists(int id)
        {
            return db.Copies.Count(e => e.Id == id) > 0;
        }
    }
}
