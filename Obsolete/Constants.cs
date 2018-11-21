using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian
{
    public static class Constants
    {
        //public static string connectionString = "server=localhost\\LIBRARYDATA;database=LibraryDatabase;Trusted_connection=yes";
        public static string Uri = "https://mylibrarianservice.azurewebsites.net/api/";
        public static string Regex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$";
    }
}
