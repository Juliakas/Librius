using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MyLibrarianFrontend.Activities;
using MyLibrarianFrontend.Items;

namespace MyLibrarianFrontend.Adapters
{
    class MyBooksAdapter : RecyclerView.Adapter
    {
        private List<Book> books;
        private Context context;
        RecyclerView recyclerView;

        public MyBooksAdapter(Context context, List<Book> books, RecyclerView recyclerView)
        {
            this.books = books;
            this.context = context;
            this.recyclerView = recyclerView;
        }

        public override int ItemCount
        {
            get { return books.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BookViewHolder viewHolder = holder as BookViewHolder;

            viewHolder.titleField.Text = books[position].Title;
            viewHolder.authorField.Text = books[position].Author;
            viewHolder.publicationField.Text = books[position].Date.ToShortDateString();
            viewHolder.dueDateField.Text = "2018-12-15";


            ((BookViewHolder)holder).Item.Click += Item_Click; 
        }

        private void Item_Click(object sender, EventArgs e)
        {
            int position = recyclerView.GetChildAdapterPosition((View)sender);
            Book book = books[position];
            MyBooksDialog bookDialog = new MyBooksDialog(book.Author, book.Title, book.Date, "2018-12-15");
            bookDialog.Show(((TabbedPagesActivity)context).SupportFragmentManager, "Book");
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.myBookView, parent, false);
            BookViewHolder viewHolder = new BookViewHolder(itemView);
            return viewHolder;
        }
    }

    class BookViewHolder : RecyclerView.ViewHolder
    {

        public TextView titleField { get; private set; }
        public TextView authorField { get; private set; }
        public TextView publicationField { get; private set; }
        public TextView dueDateField { get; private set; }
        public View Item { get; private set; }

        public BookViewHolder(View itemView) : base(itemView)
        {

            titleField = itemView.FindViewById<TextView>(Resource.Id.titleTextView);
            authorField = itemView.FindViewById<TextView>(Resource.Id.authorTextView);
            publicationField = itemView.FindViewById<TextView>(Resource.Id.publishedTextView);
            dueDateField = itemView.FindViewById<TextView>(Resource.Id.dueDateTextView);
            Item = itemView;
        }


    }
}











