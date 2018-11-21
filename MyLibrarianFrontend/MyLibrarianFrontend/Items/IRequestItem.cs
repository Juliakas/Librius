using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyLibrarianFrontend.Items
{
    public interface IRequestItem
    {
        string PrimaryKey { get; }

        string PrimaryKeyValue { get; }

        int ColumnCount { get; }

        string GetTableName();

        string[] GetColumnNames();

        string[] GetStringValues();
    }
}