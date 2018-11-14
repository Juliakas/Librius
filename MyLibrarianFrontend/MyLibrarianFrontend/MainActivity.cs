using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using System.Collections.Generic;
using Android.Content;
using Android.Views.InputMethods;

namespace MyLibrarianFrontend
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RelativeLayout relativeLayout;
        Button loginButton, registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.loginWindow);

            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            registerButton.Click += RegisterButton_Click;
            loginButton.Click += LoginButton_Click;
            relativeLayout.Click += RelativeLayout_Click; 
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
            this.Finish();
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainUserWindowActivity));
            this.StartActivity(intent);
            this.Finish();
        }

        private void RelativeLayout_Click(object sender, System.EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}