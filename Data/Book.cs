using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Book
    {
        public string ISBN { get; private set;}
        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime Date { get; private set; }

        public Book(string isbn, string title, string author, DateTime date)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Date = date;
        }
    }
}
