using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public abstract class DataItem
    {
        public abstract List<DataItem> GetAll();
    }
}
