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

namespace MyLibrarianFrontend
{
    [Activity(Label = "mainUserWindow")]
    public class AllBooksListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.booksList);

            ListView bookListView = FindViewById<ListView>(Resource.Id.bookListView);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59536/");

            List<Book> books = GetBooks(client).Result;

            var adapter = new BookAdapter(this, books, "allBooks");
            bookListView.Adapter = adapter;

        }

        private async Task<List<Book>> GetBooks(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/books");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine(data);
                return JsonConvert.DeserializeObject<List<Book>>(data);
            }
            else
            {
                return null;
            }
        }

    }
}