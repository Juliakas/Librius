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

namespace MyLibrarianFrontend
{
    [Activity(Label = "MyBooksListViewActivity")]
    public class MyBooksListViewActivity : Activity
    {
        private List<Book> books;
        private ListView bookListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.booksList);

            ListView bookListView = FindViewById<ListView>(Resource.Id.bookListView);


            List<Book> books = new List<Book>();
            Book book1 = new Book("111111111", "Balta droble", "Antanas Skema", DateTime.Parse("1962-09-01"));
            Book book2 = new Book("111111112", "Metai", "Danelaitis", DateTime.Parse("1922-09-01"));
            Book book3 = new Book("111111113", "Metai", "Danelaitis", DateTime.Parse("1922-09-01"));

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            var adapter = new BookAdapter(this, books, "myBooks");
            bookListView.Adapter = adapter;
        }
    }
}