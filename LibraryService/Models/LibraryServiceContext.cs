using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryService.Models
{
    public class LibraryServiceContext : DbContext
    {
        public LibraryServiceContext() : base(Properties.Settings.Default.LibraryServiceConnectionString)
        {
        }

        public System.Data.Entity.DbSet<LibraryService.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryService.Models.Reader> Readers { get; set; }

        public System.Data.Entity.DbSet<LibraryService.Models.Copy> Copies { get; set; }
    }
}
