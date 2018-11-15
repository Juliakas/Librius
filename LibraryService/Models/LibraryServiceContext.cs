﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryService.Models
{
    public class LibraryServiceContext : DbContext
    {
        public LibraryServiceContext() : base("Server=tcp:mylibrarian.database.windows.net,1433;Initial Catalog=LibraryDatabase;Persist Security Info=False;User ID=mylibrarian;Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
        }

        public System.Data.Entity.DbSet<LibraryService.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryService.Models.Reader> Readers { get; set; }

        public System.Data.Entity.DbSet<LibraryService.Models.Copy> Copies { get; set; }
    }
}
