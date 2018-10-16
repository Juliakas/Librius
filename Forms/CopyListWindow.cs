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
        ControllerDB database;


        public CopyListWindow(string isbn)
        {
            InitializeComponent();

            database = AuthWindow.Instance.Database;
            DataTable dt = database.GetDataTable(ControllerDB.Table.Copy);
            if (dt.Rows.Count > 0)
            {
                IEnumerable<DataRow> filtered = from rows in dt.AsEnumerable()
                                                where rows["ISBN"].ToString() == isbn
                                                select rows;
                dt = filtered.CopyToDataTable();
            }

            PopulateTable(dt);
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

        private void PopulateTable()
        {
            DataTable dt = database.GetDataTable(ControllerDB.Table.Copy);
            PopulateTable(dt);
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CopyListView.SelectedItems.Count; i++)
            {
                ListViewItem item = CopyListView.SelectedItems[i];
                string isbn = item.SubItems[0].Text;

                database.DeleteFromBook(isbn);
                PopulateTable();
            }
        }

        private void NewCopyButton_Click(object sender, EventArgs e)
        {
            database.InsertToCopy(new Copy(220868, "9789955680093"));
            PopulateTable();
        }
    }
}
