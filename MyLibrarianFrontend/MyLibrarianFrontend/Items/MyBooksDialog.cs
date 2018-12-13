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

namespace MyLibrarianFrontend.Items
{
    class MyBooksDialog : DialogFragment
    {


        String title;
        String author;
        DateTime date;
        String dueDate;

        public MyBooksDialog(String title, String author, DateTime date, String dueDate)
        {
            this.title = title;
            this.author = author;
            this.date = date;
            this.dueDate = dueDate;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.myBooksDialog, container, false);

            var titleField = view.FindViewById<TextView>(Resource.Id.titleTextView);
            var authorField = view.FindViewById<TextView>(Resource.Id.authorTextView);
            var publicationField = view.FindViewById<TextView>(Resource.Id.publishedTextView);
            var dueDateField = view.FindViewById<TextView>(Resource.Id.dueDateTextView);


            titleField.Text = title;
            authorField.Text = author;
            publicationField.Text = date.ToShortDateString();
            dueDateField.Text = dueDate;



            return view;
        }


    }
}