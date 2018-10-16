using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class Reader
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PasswordHash { get; private set; }

        public Reader(int id, string name, string surname, string passwordHash)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.PasswordHash = passwordHash;
        }

        public Reader(string name, string surname, string passwordHash) : this(0, name, surname, passwordHash) { }
    }
}
