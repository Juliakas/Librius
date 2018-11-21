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
    public class Copy : IRequestItem
    {
        public int ID { get; private set; }
        public int Reader { get; set; }
        public string ISBN { get; private set; }
        public DateTime Borrowed { get; private set; }

        public int ColumnCount { get => 2; }
        public string PrimaryKey { get => "ID"; }
        public string PrimaryKeyValue { get => ID.ToString(); }

        public Copy(int id) : this(id, default(int), default(string), default(DateTime)) { }

        public Copy(int id, string isbn) : this(id, default(int), isbn, Convert.ToDateTime("1900-01-01")) { }

        [JsonConstructor]
        public Copy(int id, int reader, string isbn, DateTime borrowed)
        {
            this.Borrowed = borrowed;
            this.ID = id;
            this.Reader = reader;
            this.ISBN = isbn;

        }

        public async static Task<List<Copy>> GetAll()
        {
            var list = await RequestClient.Instance.GetAllItemsAsync<Copy>("Copies");

            return list;
        }

        public string[] GetColumnNames()
        {
            return new string[] { "ID", "ISBN" };
        }

        public string GetTableName()
        {
            return "Copies";
        }

        public string[] GetStringValues()
        {
            return new string[] { ID.ToString(), "'" + ISBN + "'" };
        }
    }
}