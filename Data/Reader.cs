using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Reader : DataItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PasswordHash { get; private set; }

        public Reader() { }

        public Reader(int id, string name, string surname, string passwordHash)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.PasswordHash = passwordHash;
        }

        public Reader(string name, string surname, string passwordHash) : this(0, name, surname, passwordHash) { }

        public static List<Reader> GetAll()
        {
            List<Reader> list = new List<Reader>();

            DataTable dt = ControllerDB.Instance.GetDataTable(ControllerDB.Table.Reader);
            foreach (DataRow dtRow in dt.AsEnumerable())
            {
                list.Add(new Reader(Int32.Parse(dtRow["ID"].ToString()),
                    dtRow["Name"].ToString().TrimEnd(' '),
                    dtRow["Surname"].ToString().TrimEnd(' '), 
                    dtRow["Password"].ToString()));
            }

            return list;
        }
    }
}
