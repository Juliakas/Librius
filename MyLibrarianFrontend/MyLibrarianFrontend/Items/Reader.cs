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
    public class Reader
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Password { get; private set; }
     

        public Reader(string id, string name, string surname, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Password = password;
        }
    }

}
