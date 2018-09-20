using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian
{
    public partial class SignInWindow : Form
    {



        public SignInWindow()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }

        private void signInWindow_Load(object sender, EventArgs e)
        {
            UserIdPlaceholderText();
            PasswordPlaceholderText();
        }

        private void userIdGetFocus(object sender, EventArgs e)
        {
            if (userIdTextBox.Text.Equals(String.Empty) || userIdTextBox.Text.Equals("User ID"))
                LoseUserIdPlaceholderText();
        }

        private void userIdLoseFocus(object sender, EventArgs e)
        {
            if (userIdTextBox.Text.Equals(String.Empty))
                UserIdPlaceholderText();
        }

        private void passwordGetFocus(object sender, EventArgs e)
        {
            if (passwordField.Text.Equals(String.Empty) || passwordField.Text.Equals("Password"))
                LosePasswordPlaceholderText();
        }

        private void passwordLoseFocus(object sender, EventArgs e)
        {
            if (passwordField.Text.Equals(String.Empty))
                PasswordPlaceholderText();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }





        //Non event handler methods
        #region

        private void UserIdPlaceholderText()
        {
            userIdTextBox.ForeColor = Color.Gray;
            userIdTextBox.Text = "User ID";
        }

        private void LoseUserIdPlaceholderText()
        {
            userIdTextBox.Text = "";
            userIdTextBox.ForeColor = Color.Black;
        }

        private void PasswordPlaceholderText()
        {
            passwordField.ForeColor = Color.Gray;
            passwordField.PasswordChar = '\0';
            passwordField.Text = "Password";
        }

        private void LosePasswordPlaceholderText()
        {
            passwordField.Text = "";
            passwordField.ForeColor = Color.Black;
            passwordField.PasswordChar = '*';
        }

        #endregion


    }
}
