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
using MyLibrarianFrontend.Adapters;
using MyLibrarianFrontend.Items;

namespace MyLibrarianFrontend
{
    [Activity(Label = "MyBooksActivity")]
    public class MyBooksActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.booksList);


            ListView bookListView = FindViewById<ListView>(Resource.Id.bookListView);
            List<Book> books = new List<Book>();
            Book book1 = new Book("111111111", "Balta droble", "Antanas Skema", DateTime.Parse("1962-09-01"));
            Book book2 = new Book("111111112", "Metai", "Danelaitis", DateTime.Parse("1922-09-01"));
            Book book3 = new Book("111111113", "Metai", "Danelaitis", DateTime.Parse("1922-09-01"));

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            var adapter = new MyBooksAdapter(this, books);
            bookListView.Adapter = adapter;

            //PopulateList();
        }

        /*private async void PopulateList()
        {
            ListView bookListView = FindViewById<ListView>(Resource.Id.bookListView);
            List<Book> books = await Book.GetAll();

            var adapter = new MyBooksAdapter(this, books);
            bookListView.Adapter = adapter;
        }*/
    }
}