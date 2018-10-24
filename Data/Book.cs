using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Book : DataItem, IComparable<Book>
    {
        public string ISBN { get; private set;}
        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime Date { get; private set; }

        public Book() { }

        public Book(string isbn, string title, string author, DateTime date)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Date = date;
        }

        // default sorting
        public int CompareTo(Book other)
        {
            return Author.CompareTo(other.Author);
        }

        public override List<DataItem> GetAll()
        {
            List<DataItem> list = new List<DataItem>();

            DataTable dt = ControllerDB.Instance.GetDataTable(ControllerDB.Table.Book);
            foreach(DataRow dtRow in dt.AsEnumerable())
            {
                list.Add(new Book(dtRow["ISBN"].ToString(), 
                    dtRow["Title"].ToString(), 
                    dtRow["Author"].ToString(), 
                    DateTime.Parse(dtRow["Date"].ToString())));
            }

            return list;
        }
    }
}
