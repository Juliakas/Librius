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
    public partial class CheckoutListWindow : Form
    {
        MainUserWindow previousWindow;
        ControllerDB database;

        public CheckoutListWindow(MainUserWindow previousWindow)
        {
            this.previousWindow = previousWindow;
            database = ControllerDB.Instance;

            InitializeComponent();

            PopulateTable();
        }


        private async void PopulateTable()
        {
            List<Copy> copies = Copy.GetAll();
            List<Book> books = await Book.GetAll();

            var groupedList = from book in books
                              join copy in copies
                              on book.ISBN equals copy.ISBN into groupedCopies
                              select new { Book = book, Available = 
                                (
                                    from copy in groupedCopies
                                    where copy.Reader == default(int)
                                    select copy
                                )
                                .Count() };

            CopyListView.View = View.Details;
            CopyListView.Items.Clear();
            foreach (var item in groupedList)
            {
                ListViewItem listitem = new ListViewItem(item.Book.ISBN.ToString());
                listitem.SubItems.Add(item.Book.Author.ToString());
                listitem.SubItems.Add(item.Book.Title.ToString());
                listitem.SubItems.Add(item.Available.ToString());
                CopyListView.Items.Add(listitem);
            }

        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = CopyListView.SelectedItems[0].SubItems[0].Text;
                if (CopyListView.SelectedItems[0].SubItems[3].Text == "0")
                {
                    MessageManager.ShowMessageBox("There are no copies left", "Error");
                    return;
                }


                string[] columns = {"Reader", "Borrowed"};
                string[] values = {String.Format("{0:D7}", previousWindow.userId), "GETDATE()"};
                string[] conditions = { ("ID in (SELECT TOP 1 id from db_owner.Copy " +
                        $"WHERE READER IS NULL AND ISBN = {isbn} ORDER BY NEWID())") };
                database.UpdateTable(ControllerDB.Table.Copy, columns, values, conditions);

                this.Hide();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageManager.ShowMessageBox("Please select a book ISBN", "Error");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CheckoutListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackButton_Click(new object(), new EventArgs());
        }
    }
}
