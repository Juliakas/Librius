using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Librius
{
    public partial class signInWindow : Form
    {



        public signInWindow()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }

        private void signInWindow_Load(object sender, EventArgs e)
        {
            userIdPlaceholderText();
            PasswordPlaceholderText();
        }

        private void userIdGetFocus(object sender, EventArgs e)
        {
            if (userIdTextBox.Text.Equals(String.Empty) || userIdTextBox.Text.Equals("User ID"))
                loseUserIdPlaceholderText();
        }

        private void userIdLoseFocus(object sender, EventArgs e)
        {
            if (userIdTextBox.Text.Equals(String.Empty))
                userIdPlaceholderText();
        }

        private void passwordGetFocus(object sender, EventArgs e)
        {
            if (passwordField.Text.Equals(String.Empty) || passwordField.Text.Equals("Password"))
                losePasswordPlaceholderText();
        }

        private void passwordLoseFocus(object sender, EventArgs e)
        {
            if (passwordField.Text.Equals(String.Empty))
                PasswordPlaceholderText();
        }







        //Non event handler methods
        #region

        private void userIdPlaceholderText()
        {
            userIdTextBox.ForeColor = Color.Gray;
            userIdTextBox.Text = "User ID";
        }

        private void loseUserIdPlaceholderText()
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

        private void losePasswordPlaceholderText()
        {
            passwordField.Text = "";
            passwordField.ForeColor = Color.Black;
            passwordField.PasswordChar = '*';
        }

        #endregion
    }
}
