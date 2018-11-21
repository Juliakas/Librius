using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using MyLibrarianFrontend.WebClient;
using Newtonsoft.Json;

namespace MyLibrarianFrontend.Items
{
    public class Reader : IRequestItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Password { get; private set; }

        public int ColumnCount { get => 3; }
        public string PrimaryKey { get => "ID"; }
        public string PrimaryKeyValue { get => ID.ToString(); }

        [JsonConstructor]
        public Reader(int id, string name, string surname, string passwordHash)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Password = passwordHash;
        }

        public Reader(string name, string surname, string passwordHash) : this(0, name, surname, passwordHash) { }

        public async static Task<List<Book>> GetAll()
        {
            var list = await RequestClient.Instance.GetAllItemsAsync<Book> ("Readers");

            return list;
        }

        public string[] GetColumnNames()
        {
            return new string[] { "Name", "Surname", "Password" };
        }

        public string GetTableName()
        {
            return "Readers";
        }

        public string[] GetStringValues()
        {
            return new string[] { Name.SurroundWithQuotes(), Surname.SurroundWithQuotes(), Password.SurroundWithQuotes() };
        }
    }
}
