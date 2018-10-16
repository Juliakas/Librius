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

        public void FilterByCondition(Predicate<T> condition)
        {
            Collection = from T in Collection
                         where condition(T)
                         select T;
        }

    }
}
