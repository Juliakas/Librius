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


        public BooksListWindow(MainWindow previousForm)
        {
            InitializeComponent();
            database = ControllerDB.Instance;
            this.previousForm = previousForm;

            PopulateTable();
        }

        private void PopulateTable()
        {
            BookListView.View = View.Details;
            BookListView.Items.Clear();
            DataTable dt = database.GetDataTable(ControllerDB.Table.Book);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["ISBN"].ToString());
                listitem.SubItems.Add(dr["Author"].ToString());
                listitem.SubItems.Add(dr["Title"].ToString());
                listitem.SubItems.Add(DateTime.Parse(dr["Date"].ToString()).ToShortDateString());
                BookListView.Items.Add(listitem);
            }
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BookListView.SelectedItems.Count; i++)
            {
                ListViewItem item = BookListView.SelectedItems[i];
                string isbn = item.SubItems[0].Text;

                database.DeleteFromBook(isbn);
                PopulateTable();
            }
        }

        private void ShowCopiesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = BookListView.SelectedItems[0].SubItems[0].Text;

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
            this.Dispose();
        }
    }
}
