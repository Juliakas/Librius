using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyLibrarianFrontend.Items;
using Newtonsoft.Json;
using System.Web;
using System.Security.Policy;
using MyLibrarianFrontend.WebClient;

namespace MyLibrarianFrontend
{
    [Activity(Label = "mainUserWindow")]
    public class AllBooksListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.booksList);

            PopulateList();
        }

        private async void PopulateList()
        {
            ListView bookListView = FindViewById<ListView>(Resource.Id.bookListView);
            List<Book> books = await Book.GetAll();

            var adapter = new BookAdapter(this, books, "allBooks");
            bookListView.Adapter = adapter;
        }
    }
}