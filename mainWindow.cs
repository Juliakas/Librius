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
    public partial class MainWindow : Form 
    {
        private String firstName;
        private String lastName;
        private int id;

        private String title;
        private String author;
        private String isbn;
        private DateTime date;

        ControllerDB database;

        public MainWindow()
        {
            InitializeComponent();

            database = new ControllerDB("MyLibrarian.Properties.Settings.LibraryDatabaseConnectionString");
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(firstNameTextBox.Text)
                || string.IsNullOrEmpty(lastNameTextBox.Text)
                || string.IsNullOrEmpty(idTextBox.Text)))
            {
                firstName = firstNameTextBox.Text;
                lastName = lastNameTextBox.Text;
                if (idTextBox.Text.Length == 7)
                {
                    id = Convert.ToInt32(idTextBox.Text);
                    database.AddItemsToSkaitytojas(id, firstName, lastName);
                }

                else
                {
                    string message = "id field must have 7 characters!";
                    string caption = "Invalid field";
                    MessageBox.Show(message, caption);
                }
            }
            else
            {
                string message = "Not all fields are filled!";
                string caption = "Empty fields";
                MessageBox.Show(message, caption);
            }

        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(titleTextBox.Text) 
                || string.IsNullOrEmpty(authorTextBox.Text) 
                || string.IsNullOrEmpty(isbnTextBox.Text) 
                || string.IsNullOrEmpty(pDateTextBox.Text)))
            {
                if (DateTime.TryParse(pDateTextBox.Text, out date))
                {
                    
                    title = titleTextBox.Text;
                    author = authorTextBox.Text;
                    isbn = isbnTextBox.Text;
                    Console.WriteLine(date.Year);
                }
                else
                {
                    string message = "This date is invalid";
                    string caption = "Invalid date";
                    DialogResult result;
                    result = MessageBox.Show(message, caption);
                }
            }
            else
            {
                string message = "Not all fields are filled";
                string caption = "Empty fields";
                DialogResult result;
                result = MessageBox.Show(message, caption);
            }
        }

        private void showUsersButton_Click(object sender, EventArgs e)
        {
            UsersListWindow usersListWindow = new UsersListWindow();
            usersListWindow.Show();
        }

        private void showBooksButton_Click(object sender, EventArgs e)
        {
            BooksListWindow booksListWindow = new BooksListWindow();
            booksListWindow.Show();
        }

        
    }
}
