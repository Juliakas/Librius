using MyLibrarian.Data;
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
    public partial class CopyListWindow : Form
    {
        private readonly ControllerDB database;
        private readonly string isbn;
        private readonly BooksListWindow previousForm;

        public CopyListWindow(BooksListWindow previousForm, string isbn)
        {
            InitializeComponent();

            this.isbn = isbn;
            this.previousForm = previousForm;
            database = AuthWindow.Instance.Database;

            PopulateTable();
        }


        private void PopulateTable(DataTable dt)
        {
            CopyListView.View = View.Details;
            CopyListView.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["ID"].ToString());
                listitem.SubItems.Add(dr["Reader"].ToString());
                listitem.SubItems.Add(dr["Borrowed"].ToString());
                CopyListView.Items.Add(listitem);
            }
        }

        internal void PopulateTable()
        {
            DataTable dt = database.GetDataTable(ControllerDB.Table.Copy);
            LINQ<DataRow> filter = new LINQ<DataRow>(dt.AsEnumerable());
            filter.FilterByCondition(rows => rows["ISBN"].ToString() == isbn);
            try
            {
                dt = filter.Collection.CopyToDataTable();
            }
            catch (ArgumentNullException ex)
            {
                dt.Clear();
            }
            finally
            {
                PopulateTable(dt);
            }
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CopyListView.SelectedItems.Count; i++)
            {
                ListViewItem item = CopyListView.SelectedItems[i];
                Int64 id = Int64.Parse(item.SubItems[0].Text);

                database.DeleteFromCopy(id);
                PopulateTable();
            }
        }

        private void NewCopyButton_Click(object sender, EventArgs e)
        {
            new AddCopyWindow(this, isbn).ShowDialog();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Dispose();
        }
    }
}
