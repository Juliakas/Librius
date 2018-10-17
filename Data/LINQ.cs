using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public class LINQ <T>
    {

        public delegate bool Predicate<in T, in U>(T obj1, U obj2);

        public IEnumerable<T> Collection { get; private set; }
        public int Count
        {
            get
            {
                return Collection.Count();
            }
        }

        public LINQ (IEnumerable<T> collection)
        {
            Collection = collection;
        }

        public void Filter(Predicate<T> condition)
        {
            Collection = from obj in Collection
                         where condition(obj)
                         select obj;
        }

    }
}
