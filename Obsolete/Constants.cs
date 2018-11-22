using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian
{
    public static class Constants
    {
        public static string Uri = Properties.Settings.Default.URL;
        public static string Regex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$";
    }
}
