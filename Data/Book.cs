using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Book
    {
        public string isbn { get; private set;}
        public string title { get; private set; }
        public string author { get; private set; }
        public DateTime date { get; private set; }

        public Book(string isbn, string title, string author, DateTime date)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.date = date;
        }
    }
}
