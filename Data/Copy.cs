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
        public Int64 ID { get; private set; }
        public int Reader { get; set; }
        public string ISBN { get; private set; }
        public DateTime Borrowed { get; private set; }

        public Copy() { }

        public Copy(Int64 id, string isbn) : this(id, default(int), isbn, default(DateTime)) { }

        public Copy(Int64 id, int reader, string isbn, DateTime borrowed)
        {
            this.ID = id;
            this.Reader = reader;
            this.ISBN = isbn;
            this.Borrowed = borrowed;
        }

        public static List<Copy> GetAll()
        {
            List<Copy> list = new List<Copy>();

            DataTable dt = ControllerDB.Instance.GetDataTable(ControllerDB.Table.Copy);
            foreach (DataRow dtRow in dt.AsEnumerable())
            {
                list.Add(new Copy(Int64.Parse(dtRow["ID"].ToString()),
                    String.IsNullOrEmpty(dtRow["Reader"].ToString()) 
                    ? default(int) : Int32.Parse(dtRow["Reader"].ToString()),
                    dtRow["ISBN"].ToString(),
                    String.IsNullOrEmpty(dtRow["Borrowed"].ToString()) 
                    ? default(DateTime) : DateTime.Parse(dtRow["Borrowed"].ToString())));
            }

            return list;
        }

    }
}
