using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MyLibrarianFrontend.Fragments;

namespace MyLibrarianFrontend.Adapters
{
    class BookPagerAdapter : FragmentPagerAdapter
    {
        int numOfTabs;


        public BookPagerAdapter(Android.Support.V4.App.FragmentManager fragmentManager, int numOfTabs) : base(fragmentManager)
        {
            this.numOfTabs = numOfTabs;
        }
        public override int Count
        {
            get
            {
                return numOfTabs;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new AllBooksFragment();
                case 1:
                    return new MyBooksFragment();
                default:
                    return null;
            }
        }
        public override ICharSequence GetPageTitleFormatted(int position)
        {
            switch (position)
            {
                case 0:
                    return new Java.Lang.String("All Books");
                case 1:
                    return new Java.Lang.String("My Books");
                default:
                    return null;
            }
        }


    }
}
