using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Copy
    {
        public Int64 ID { get; private set; }
        public int Reader { get; set; }
        public string ISBN { get; private set; }
        public DateTime Borrowed { get; private set; }

        public Copy(Int64 id, string isbn)
        {
            this.ID = id;
            this.ISBN = isbn;
        }



    }
}
