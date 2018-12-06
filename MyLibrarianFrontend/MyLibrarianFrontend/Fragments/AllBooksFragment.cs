using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyLibrarianFrontend.Adapters;
using MyLibrarianFrontend.Items;

namespace MyLibrarianFrontend.Fragments
{
    public class AllBooksFragment : Fragment
    {
        ListView bookListView;
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

            var view = inflater.Inflate(Resource.Layout.booksList, container, false);


            bookListView = view.FindViewById<ListView>(Resource.Id.bookListView);



            return view;
        }

        public async override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            List<Book> books = await Book.GetAll();
            var adapter = new AllBooksAdapter(this.Activity, books);
            bookListView.Adapter = adapter;
        }
    }
}