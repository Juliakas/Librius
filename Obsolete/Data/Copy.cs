using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Copy : DataItem
    {
        public int ID { get; private set; }
        public int Reader { get; set; }
        public string ISBN { get; private set; }
        public DateTime Borrowed { get; private set; }

        public override int ColumnCount { get => 2; }
        public override string PrimaryKey { get => "ID"; }
        public override string PrimaryKeyValue { get => ID.ToString(); }

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
            var list = await DataProcessing.HttpManager.Instance.GetAllItemsAsync<Copy>("Copies");

            return list;
        }

        public override string[] GetColumnNames()
        {
            return new string[] { "ID", "ISBN" };
        }

        public override string GetTableName()
        {
            return "Copies";
        }

        public override string[] GetStringValues()
        {
            return new string[] { ID.ToString(), "'" + ISBN + "'" };
        }
    }
}
