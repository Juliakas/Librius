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
using MyLibrarianFrontend.Items;
using MyLibrarianFrontend.WebClient;

namespace MyLibrarianFrontend
{
    public delegate void RegisterEvent(object sender, EventArgs e);

    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        private event RegisterEvent Registered;

        private EditText firstNameField;
        private EditText lastNameField;
        private EditText passwordField;
        private EditText confirmField;
        private Button registerButton;
        private RelativeLayout relativeLayout;
        private ProgressBar progressBar;
        private TextView redLabel;
        private ImageView userImageView;

        public static readonly int PickImageId = 1000;
        private Android.Net.Uri imageUri;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.registrationWindow);

            firstNameField = FindViewById<EditText>(Resource.Id.firstNameEditText);
            lastNameField = FindViewById<EditText>(Resource.Id.lastNameEditText);
            passwordField = FindViewById<EditText>(Resource.Id.passwordEditText);
            confirmField = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);
            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            redLabel = FindViewById<TextView>(Resource.Id.redLabel);
            userImageView = FindViewById<ImageView>(Resource.Id.userPhotoImageView);


            registerButton.Click += RegisterButton_Click;
            relativeLayout.Click += RelativeLayout_Click;
            userImageView.Click += UserImageView_Click;
            confirmField.FocusChange += (sender, e) => { redLabel.Visibility = ViewStates.Invisible; };
            Registered += User_RegisteredAsync;
        }


        private void UserImageView_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                imageUri = data.Data;
                userImageView.SetImageURI(imageUri);
            }
        }

        private void RelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            registerButton.Click -= RegisterButton_Click;
            if (passwordField.Text != confirmField.Text)
            {
                redLabel.Visibility = ViewStates.Visible;
                registerButton.Click += RegisterButton_Click;
                return;
            }

            progressBar.Visibility = ViewStates.Visible;
            Registered.Invoke(this, null);
        }

        private async void User_RegisteredAsync(object sender, EventArgs e)
        {
            string firstName = firstNameField.Text;
            string lastName = lastNameField.Text;
            string password = passwordField.Text;
            string id = await RequestClient.Instance.PostItemAsync(new Reader(firstName, lastName, password), "signup");
            Console.WriteLine("User id: " + id);

            try
            {
                var inputStream = ContentResolver.OpenInputStream(imageUri);

                var imageName = await ImageManager.UploadImage(inputStream, id);

                /*new AlertDialog.Builder(this)
                    .SetMessage("Image uploaded successfully!. Image name: " + imageName)
                    .SetTitle("Image upload")
                    .Show();*/
            }
            catch (Exception ex)
            {
                /*new AlertDialog.Builder(this)
                    .SetMessage("The image could not be uploaded. Error " + ex.Message)
                    .SetTitle("Image upload")
                    .Show();*/
            }

            progressBar.Visibility = ViewStates.Invisible;
            this.Finish();
        }



    }
}