using MyLibrarian.Data;
using MyLibrarian.Forms.Utils;
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
    public partial class BooksListWindow : Form
    {
        private readonly ControllerDB database;
        private readonly MainWindow previousForm;
        List<Book> books;

        public BooksListWindow(MainWindow previousForm)
        {
            InitializeComponent();

            database = ControllerDB.Instance;
            this.previousForm = previousForm;

            sortingTypeComboBox.SelectedIndex = 0;
        }

        private async void PopulateTable()
        {
            books = await Book.GetAll();

            BookListView.View = View.Details;
            BookListView.Items.Clear();
            foreach (Book book in books)
            {
                ListViewItem listitem = new ListViewItem(book.ISBN);
                listitem.SubItems.Add(book.Author);
                listitem.SubItems.Add(book.Title);
                listitem.SubItems.Add(book.Date.ToShortDateString());
                BookListView.Items.Add(listitem);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BookListView.SelectedItems.Count; i++)
            {
                ListViewItem item = BookListView.SelectedItems[i];
                string isbn = item.SubItems[0].Text;

                DeleteCopies(isbn);
                database.DeleteRow(new Book(isbn));

                PopulateTable();
            }
        }

        private async void DeleteCopies(string isbn)
        {
            List<Copy> copies = await Copy.GetAll();

            var filteredList = from copy in copies
                               where copy.ISBN == isbn
                               select copy;

            foreach(var item in filteredList)
            {
                database.DeleteRow(new Copy(item.ID));
            }
        }

        private void ShowCopiesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = BookListView.SelectedItems[0].SubItems[0].Text;
                MessageManager.ShowMessageBox(isbn);

                this.Hide();

                new CopyListWindow(this, isbn).Show();
            }
            catch(System.ArgumentOutOfRangeException ex)
            {
                MessageManager.ShowMessageBox("Please select a book's ISBN");
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Hide();
        }

        private void BooksListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackButton_Click(new object(), new EventArgs());
        }

        private async void sortingTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookComparer bookComparer = new BookComparer();
            List<Book> books = await Book.GetAll();

            string selectedSortingType = sortingTypeComboBox.GetItemText(sortingTypeComboBox.SelectedItem);

            if (selectedSortingType == "Author desc")
            {
                bookComparer.sortBy = BookComparer.CompareType.authorDesc;
            }
            else if (selectedSortingType == "Title asc")
            {
                bookComparer.sortBy = BookComparer.CompareType.titleAsc;
            }
            else if (selectedSortingType == "Title desc")
            {
                bookComparer.sortBy = BookComparer.CompareType.titleDesc;
            }
            else if (selectedSortingType == "Date asc")
            {
                bookComparer.sortBy = BookComparer.CompareType.dateAsc;
            }
            else if (selectedSortingType == "Date desc")
            {
                bookComparer.sortBy = BookComparer.CompareType.dateDesc;
            }
            else
            {
                bookComparer.sortBy = BookComparer.CompareType.authorAsc;
            }

            books.Sort(bookComparer);

            BookListView.Items.Clear();
            PopulateTable();
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text == "" || AuthorTextBox.Text == "")
            {
                MessageManager.ShowMessageBox("Some fields are empty");
            }
            else
            {
                Book book = new Book("", TitleTextBox.Text.ToString(), AuthorTextBox.Text.ToString(), DateTime.Now);
                if (books.Contains(book))
                {
                    MessageManager.ShowMessageBox("Book is in the list");

                }
                else
                {
                    MessageManager.ShowMessageBox("Nothing found");
                }
            }
        }
    }
}
