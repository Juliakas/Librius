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

namespace MyLibrarianFrontend
{
    class BookAdapter : BaseAdapter<Book>
    {

        private List<Book> books;
        private Activity activity;
        string type;

        public BookAdapter(Activity activity, List<Book> items, string type)
        {
            this.books = items;
            this.activity = activity;
            this.type = type;
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
            if (type == "all ")
            {
                var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.bookView, parent, false);
                var titleField = view.FindViewById<TextView>(Resource.Id.titleTextView);
                var authorField = view.FindViewById<TextView>(Resource.Id.authorTextView);
                var publicationField = view.FindViewById<TextView>(Resource.Id.publishedTextView);
                var amountField = view.FindViewById<TextView>(Resource.Id.amountTextView);

                titleField.Text = books[position].Title;
                authorField.Text = books[position].Author;
                publicationField.Text = books[position].Date.ToShortDateString();
                amountField.Text = "0";

                return view;
            }

            else
            {
                var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.myBookView, parent, false);
                var titleField = view.FindViewById<TextView>(Resource.Id.titleTextView);
                var authorField = view.FindViewById<TextView>(Resource.Id.authorTextView);
                var publicationField = view.FindViewById<TextView>(Resource.Id.publishedTextView);
                var returnField = view.FindViewById<TextView>(Resource.Id.returnDateTextView);

                titleField.Text = books[position].Title;
                authorField.Text = books[position].Author;
                publicationField.Text = books[position].Date.ToShortDateString();
                returnField.Text ="2018-12-01";


                return view;
            }

        }
    }
}