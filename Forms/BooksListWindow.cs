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
        DataTable dt;
        ControllerDB database;


        public BooksListWindow()
        {
            InitializeComponent();
            MainWindow main = MainWindow.Instance;
            database = AuthWindow.Instance.Database;

            PopulateTable();
        }


        private void PopulateTable()
        {
            bookListView.View = View.Details;
            bookListView.Items.Clear();
            dt = database.GetDataTable(ControllerDB.Table.Book);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["ISBN"].ToString());
                listitem.SubItems.Add(dr["Title"].ToString());
                listitem.SubItems.Add(dr["Author"].ToString());
                listitem.SubItems.Add(DateTime.Parse(dr["Date"].ToString()).ToShortDateString());
                bookListView.Items.Add(listitem);
            }
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bookListView.SelectedItems.Count; i++)
            {
                ListViewItem item = bookListView.SelectedItems[i];
                string isbn = item.SubItems[0].Text;

                database.DeleteFromBook(isbn);
                PopulateTable();
            }
        }
    }
}
