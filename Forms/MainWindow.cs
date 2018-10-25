using MyLibrarian.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrarian.Data;
using MyLibrarian.Forms.Utils;

namespace MyLibrarian.Forms
{
    public partial class MainWindow : Form 
    {
        
        private readonly ControllerDB Database;
        private readonly AuthWindow previousWindow;

        public MainWindow(AuthWindow previousWindow)
        {
            InitializeComponent();
            Database = ControllerDB.Instance;
            this.previousWindow = previousWindow;
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            BackButton_Click(new object(), new EventArgs());
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(titleTextBox.Text) 
                || string.IsNullOrEmpty(authorTextBox.Text) 
                || string.IsNullOrEmpty(isbnTextBox.Text) 
                || string.IsNullOrEmpty(pDateTextBox.Text)))
            {
                if (isbnTextBox.Text.Length == 13)
                {
                    DateTime date;
                    DateTime.TryParse(pDateTextBox.Text, out date);
                    string title = titleTextBox.Text;
                    string author = authorTextBox.Text;
                    string isbn = isbnTextBox.Text;

                    Database.InsertRow(new Book(isbn, title, author, date));
                }
                else
                {
                    string message = "ISBN field must have 13 characters!";
                    string caption = "Invalid fields";
                    MessageManager.ShowMessageBox(optionalCaption: caption, text: message);
                }


            }
            else
            {
                string message = "Not all fields are filled!";
                string caption = "Empty fields";
                MessageManager.ShowMessageBox(optionalCaption: caption, text: message);
            }
        }

        private void showBooksButton_Click(object sender, EventArgs e)
        {
            BooksListWindow booksListWindow = new BooksListWindow(this);
            booksListWindow.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousWindow.Show();
        }
    }
}
