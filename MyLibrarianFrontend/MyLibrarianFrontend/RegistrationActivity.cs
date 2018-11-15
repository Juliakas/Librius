using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace MyLibrarianFrontend
{
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        Button registerButton;
        RelativeLayout relativeLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registrationWindow);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);
            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout);

            registerButton.Click += RegisterButton_Click;
            relativeLayout.Click += RelativeLayout_Click; ;
        }

        private void RelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AllBooks));
            this.StartActivity(intent);
        }
    }
}