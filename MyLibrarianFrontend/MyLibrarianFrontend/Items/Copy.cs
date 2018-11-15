using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyLibrarianFrontend.Items
{
    public class Copy
    {
        public string ID { get; private set; }
        public string ISBN { get; private set; }
        public string Reader { get; private set; }
        public DateTime Borrowed { get; private set; }
     

        public Copy(string id, string isbn, string reader, DateTime borrowed)
        {
            this.ID = id;
            this.ISBN = isbn;
            this.Reader = reader;
            this.Borrowed = borrowed;
        }
    }

}
