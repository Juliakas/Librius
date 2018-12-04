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
using MyLibrarianFrontend.Items;

namespace MyLibrarianFrontend.Adapters
{
    class MyBooksAdapter : BaseAdapter<Book>
    {

        private List<Book> books;
        private Activity activity;

        public MyBooksAdapter(Activity activity, List<Book> items)
        {
            this.books = items;
            this.activity = activity;
        }

        public override int Count
        {
            get { return books.Count; }
        }

        public override Book this[int position]
        {
            get { return books[position]; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.myBookView, parent, false);
            var titleField = view.FindViewById<TextView>(Resource.Id.titleTextView);
            var authorField = view.FindViewById<TextView>(Resource.Id.authorTextView);
            var publicationField = view.FindViewById<TextView>(Resource.Id.publishedTextView);
            var returnField = view.FindViewById<TextView>(Resource.Id.returnDateTextView);

            titleField.Text = books[position].Title;
            authorField.Text = books[position].Author;
            publicationField.Text = books[position].Date.ToShortDateString();
            returnField.Text = "2018-12-01";

            return view;
        }
    }
}