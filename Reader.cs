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
        //private int startingNumber = 1710000;

        public Reader(int id, string name, string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }
    }
}
