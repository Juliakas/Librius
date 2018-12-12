using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyLibrarianFrontend.Adapters;
using MyLibrarianFrontend.Items;

namespace MyLibrarianFrontend.Fragments
{
    public class MyBooksFragment : Fragment
    {
        RecyclerView bookListView;
        List<Book> books;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.recyclerView, container, false);


            bookListView = view.FindViewById<RecyclerView>(Resource.Id.bookListView);


            books = new List<Book>();
            Book book1 = new Book("111111111", "Balta drobule", "Antanas Skema", DateTime.Parse("1962-09-01"));

            books.Add(book1);

            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(this.Activity);
            bookListView.SetLayoutManager(layoutManager);
            var adapter = new MyBooksAdapter(Context, books, bookListView);
            bookListView.SetAdapter(adapter);
        }

    }
}