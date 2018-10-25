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
    public partial class MainUserWindow : Form
    {
        internal readonly int userId;
        private string firstName;
        private string lastName;
        ControllerDB database;
        AuthWindow previousWindow;

        public MainUserWindow(AuthWindow previousWindow, int userId)
        {
            InitializeComponent();

            this.userId = userId;
            this.previousWindow = previousWindow;
            database = ControllerDB.Instance;

            FillSessionLabel();

            PopulateTable();
        }

        private void FillSessionLabel()
        {
            List<Reader> readers = Reader.GetAll();

            var currentReader = from reader in readers
                                where reader.ID == userId
                                select reader;

            firstName = currentReader.First().Name;
            lastName = currentReader.First().Surname;

            SessionLabel.Text += String.Format("{0:D7}\n{1} {2}", userId, firstName, lastName);
        }

        private void PopulateTable()
        {
            CopyListView.View = View.Details;
            CopyListView.Items.Clear();

            //DataTable dt = database.GetJoinedDataTable(ControllerDB.Table.Copy,
            //    ControllerDB.Table.Book, new string[] { "ID", "Author", "Title", "Borrowed" },
            //    new string[] { "db_owner.Book.ISBN = db_owner.Copy.ISBN ", "db_owner.Copy.Reader = " + userId });

            List<Copy> copies = Copy.GetAll();
            List<Book> books = Book.GetAll();

            var table = from copy in copies
                        join book in books
                        on copy.ISBN equals book.ISBN
                        where copy.Reader == userId
                        select new { Copy = copy, Book = book };

            foreach(var item in table)
            {
                ListViewItem listitem = new ListViewItem(item.Copy.ID.ToString());
                listitem.SubItems.Add(item.Book.Author.ToString());
                listitem.SubItems.Add(item.Book.Title.ToString());
                listitem.SubItems.Add(item.Copy.Borrowed.ToString());
                CopyListView.Items.Add(listitem);
            }

            //LINQ<DataRow> filter = new LINQ<DataRow>(dt.AsEnumerable());
            //filter.Filter(row =>
            //{
            //    if (row["Reader"].GetType() == Type.GetType("System.DBNull"))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return Int32.Parse(row["Reader"].ToString()) == userId
            //            && row["ISBN"].ToString() == row["ISBN1"].ToString();
            //    }
            //});
            //try
            //{
            //    dt = filter.Collection.CopyToDataTable();
            //}
            //catch (InvalidOperationException ex)
            //{
            //    dt.Clear();
            //}

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    ListViewItem listitem = new ListViewItem(dr["ID"].ToString());
            //    listitem.SubItems.Add(dr["Author"].ToString());
            //    listitem.SubItems.Add(dr["Title"].ToString());
            //    listitem.SubItems.Add(dr["Borrowed"].ToString());
            //    CopyListView.Items.Add(listitem);
            //}
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            previousWindow.Show();
            this.Hide();
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            new CheckoutListWindow(this).ShowDialog();
            PopulateTable();
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = CopyListView.SelectedItems[0].SubItems[0].Text;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageManager.ShowMessageBox("Please select a book ID", "Error");
                return;
            }

            string[] columns = { "Reader", "Borrowed" };
            string[] values = { "NULL", "NULL" };
            string[] conditions = { $"{userId} = Reader", $"{id} = ID"};
            database.UpdateTable(ControllerDB.Table.Copy, columns, values, conditions);

            PopulateTable();
        }

        private void MainUserWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogOutButton_Click(new object(), new EventArgs());
        }
    }
}
