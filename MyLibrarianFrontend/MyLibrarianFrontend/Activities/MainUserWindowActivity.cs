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
    [Activity(Label = "MainUserWindowActivity")]
    public class MainUserWindowActivity : Activity
    {
        Button myBooksButton, allBooksButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainUWindow);

            myBooksButton = FindViewById<Button>(Resource.Id.myBooksButton);
            allBooksButton = FindViewById<Button>(Resource.Id.allBooksButton);

            myBooksButton.Click += MyBooksButton_Click;
            allBooksButton.Click += AllBooksButton_Click;
        }

        private void AllBooksButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AllBooksListActivity));
            this.StartActivity(intent);
        }

        private void MyBooksButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MyBooksListViewActivity));
            this.StartActivity(intent);
        }
    }
}