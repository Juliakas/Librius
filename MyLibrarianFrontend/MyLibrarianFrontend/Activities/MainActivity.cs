using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using System.Collections.Generic;
using Android.Content;
using Android.Views.InputMethods;
using Android.Views;
using MyLibrarianFrontend.WebClient;
using MyLibrarianFrontend.Items;
using System;
using System.Net;
using MyLibrarianFrontend.Activities;

namespace MyLibrarianFrontend
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private event Action<object, EventArgs> SignInFailed;

        private LinearLayout linearLayout;
        private EditText userIdField;
        private EditText passwordField;
        private Button loginButton, registerButton;
        private ProgressBar progressBar;
        private TextView redlabel;

        int signInAttempts = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.loginWindow);
            object clnt = RequestClient.Instance;

            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout);
            userIdField = FindViewById<EditText>(Resource.Id.userIdEditText);
            passwordField = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            redlabel = FindViewById<TextView>(Resource.Id.redLabel);

            registerButton.Click += RegisterButton_Click;
            loginButton.Click += LoginButton_Click;
            passwordField.FocusChange += (sender, e) => { redlabel.Visibility = ViewStates.Invisible; };
            linearLayout.Click += LinearLayout_Click;
            SignInFailed += SignInFailed_InvalidId;
        }

        private void LinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = ViewStates.Visible;
            if (signInAttempts >= 5)
            {
                SignInFailed += SignInFailed_Exit;
            }

            if (!int.TryParse(userIdField.Text, out int id))
            {
                SignInFailed.Invoke(this, new EventArgs());
                return;
            }
            AuthenticateUserAsync(id);
        }

        private async void AuthenticateUserAsync(int id)
        {

            Reader user = new Reader(id, "name", "name", passwordField.Text);

            try
            {
                await RequestClient.Instance.PostItemAsync(user, "signin");
            }
            catch(BadHttpStatusCodeException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    SignInFailed.Invoke(this, new EventArgs());
                    return;
                }
                else return;
            }

            signInAttempts = 0;
            progressBar.Visibility = ViewStates.Invisible;
            Intent intent = new Intent(this, typeof(TabbedPagesActivity));
            this.StartActivity(intent);
        }

        private void SignInFailed_InvalidId(object sender, EventArgs e)
        {
            progressBar.Visibility = ViewStates.Invisible;
            signInAttempts++;
            passwordField.Text = "";
            passwordField.ClearFocus();
            redlabel.Visibility = ViewStates.Visible;
        }

        private void SignInFailed_Exit(object sender, EventArgs e)
        {
            this.Finish();
        }

    }
}