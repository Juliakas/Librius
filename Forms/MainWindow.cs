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

namespace MyLibrarian.Forms
{
    public partial class MainWindow : Form 
    {
        
        ControllerDB Database;

        public MainWindow()
        {
            InitializeComponent();
            Database = AuthWindow.Instance.Database;
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {

            AuthWindow.Instance.Database.Close();
            Application.Exit();
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

                    Database.InsertToBook(new Book(isbn, title, author, date));
                }
                else
                {
                    string message = "ISBN field must have 13 characters!";
                    string caption = "Invalid fields";
                    MessageManager.ShowMessageBox(message, caption);
                }


            }
            else
            {
                string message = "Not all fields are filled!";
                string caption = "Empty fields";
                MessageManager.ShowMessageBox(message, caption);
            }
        }

        private void showBooksButton_Click(object sender, EventArgs e)
        {
            BooksListWindow booksListWindow = new BooksListWindow();
            booksListWindow.Show();
        }

        private void faceRecognitionButton_Click(object sender, EventArgs e)
        {
            RecogniseFaceWindow recogniseFaceWindow = new RecogniseFaceWindow();
            recogniseFaceWindow.Show();
        }
    }
}
