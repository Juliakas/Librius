using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using MyLibrarianFrontend.Adapters;

namespace MyLibrarianFrontend.Activities
{
    [Activity(Label = "TabbedPagesActivity")]
    public class TabbedPagesActivity : AppCompatActivity
    {

        TabLayout tabLayout;
        ViewPager viewPager;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tab);
   
            tabLayout = FindViewById<TabLayout>(Resource.Id.tablayout);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            BookPagerAdapter bookPagerAdapter = new BookPagerAdapter(SupportFragmentManager, 2);
            viewPager.Adapter = bookPagerAdapter;

            tabLayout.SetupWithViewPager(viewPager);
        }
    }
}