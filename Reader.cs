using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian
{
    public class Reader
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string surname { get; private set; }
        public string hash { get; private set; }

        public Reader(int id, string name, string surname, string hash)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.hash = hash;
        }
    }
}
