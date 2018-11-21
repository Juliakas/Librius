using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using MyLibrarian.DataProcessing;
using Newtonsoft.Json;

namespace MyLibrarian.Data
{
    public class Reader : DataItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Password { get; private set; }

        public override int ColumnCount { get => 3; }
        public override string PrimaryKey { get => "ID"; }
        public override string PrimaryKeyValue { get => ID.ToString(); }

        [JsonConstructor]
        public Reader(int id, string name, string surname, string passwordHash)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Password = passwordHash;
        }

        

        public Reader(string name, string surname, string passwordHash) : this(0, name, surname, passwordHash) { }

        public async static Task<List<Reader>> GetAll()
        {
            var list = await HttpManager.Instance.GetAllItemsAsync<Reader>("Readers");

            return list;
        }

        public override string[] GetColumnNames()
        {
            return new string[] { "Name", "Surname", "Password" };
        }

        public override string GetTableName()
        {
            return "Readers";
        }

        public override string[] GetStringValues()
        {
            return new string[] { Name.SurroundWithQuotes(), Surname.SurroundWithQuotes(), Password.SurroundWithQuotes() };
        }
    }
}
