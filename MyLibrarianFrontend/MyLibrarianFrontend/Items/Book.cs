using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyLibrarianFrontend.WebClient;
using Newtonsoft.Json;

namespace MyLibrarianFrontend.Items
{
    public class Book : IRequestItem
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime Date { get; private set; }

        public int ColumnCount { get => 4; }
        public string PrimaryKey { get => "ISBN"; }
        public string PrimaryKeyValue { get => ISBN; }

        public Book(string isbn) : this(isbn, default(string), default(string), default(DateTime)) { }

        [JsonConstructor]
        public Book(string isbn, string title, string author, DateTime date)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Date = date;
        }

        public async static Task<List<Book>> GetAll()
        {
            var list = await RequestClient.Instance.GetAllItemsAsync<Book>("Books");

            return list;
        }

        public string[] GetColumnNames()
        {
            return new string[] { "ISBN", "Title", "Author", "Date" };
        }

        public string GetTableName()
        {
            return "Books";
        }

        public string[] GetStringValues()
        {
            return new string[] { "'" + ISBN + "'", "'" + Title + "'", "'" + Author + "'", "'" + Date.ToString("yyyyMMdd") + "'" };
        }
    }
}
