using MyLibrarian.Data;
using MyLibrarian.Forms.Utils;
using MyLibrarian.DataProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Forms
{
    public partial class AuthWindow : Form
    {

        private int userId;
        private string password;

        internal ControllerDB Database { get; }

        public AuthWindow()
        {
            InitializeComponent();

            Database = ControllerDB.Instance;

            UserIdPlaceholderText();
            PasswordPlaceholderText();
        }

        #region Placeholder text methods
        private void UserIdPlaceholderText()
        {
            UserIdBox.ForeColor = Color.Gray;
            UserIdBox.Text = "User ID";
        }

        private void LoseUserIdPlaceholderText()
        {
            UserIdBox.Text = "";
            UserIdBox.ForeColor = Color.Black;
        }

        private void PasswordPlaceholderText()
        {
            PasswordBox.ForeColor = Color.Gray;
            PasswordBox.PasswordChar = '\0';
            PasswordBox.Text = "Password";
        }

        private void LosePasswordPlaceholderText()
        {
            PasswordBox.Text = "";
            PasswordBox.ForeColor = Color.Black;
            PasswordBox.PasswordChar = '*';
        }

        #endregion Non event handler methods

        private async void LogInButton_Click(object sender, EventArgs e)
        {
            userId = int.Parse(UserIdBox.Text.ToString());
            password = PasswordBox.Text.ToString();
            
            string id = await HttpManager.Instance.PostItemAsync(new Reader(userId, "", "", password), "signin");

            if (id != null)
            {
                PasswordBox.Clear();
                new MainUserWindow(this, userId).Show();
                this.Hide();
            }
            else
            {
                MessageManager.ShowMessageBox("Incorrect User ID and / or Password");
            }
            
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            new MainWindow(this).Show();
            this.Hide();
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.ForeColor == Color.Gray)
            {
                LosePasswordPlaceholderText();
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PasswordBox.Text))
            {
                PasswordPlaceholderText();
            }
        }

        private void UserIdBox_Enter(object sender, EventArgs e)
        {
            if (UserIdBox.ForeColor == Color.Gray)
            {
                LoseUserIdPlaceholderText();
            }
        }

        private void UserIdBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserIdBox.Text))
            {
                UserIdPlaceholderText();
            }
        }

        private void UserIdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            new RegistrationWindow(this).ShowDialog();
        }
    }
}
