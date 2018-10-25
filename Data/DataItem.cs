using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    public abstract class DataItem
    {
        public abstract string PrimaryKey { get; }

        public abstract string PrimaryKeyValue { get; }

        public abstract int ColumnCount { get; }

        public abstract string GetTableName();

        public abstract string[] GetColumnNames();

        public abstract string[] GetStringValues();
    }
}
