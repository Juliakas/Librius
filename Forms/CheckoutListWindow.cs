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


        private void PopulateTable()
        {
            //SELECT Book.ISBN, Title, Author, SUM(
            //    CASE
            //        WHEN db_owner.Copy.Reader IS NULL THEN 1
            //        ELSE 0
            //    END) AS Available
            //FROM db_owner.Book, db_owner.Copy
            //WHERE db_owner.Book.ISBN = db_owner.Copy.ISBN
            //GROUP BY Book.ISBN, Title, Author

            CopyListView.View = View.Details;
            CopyListView.Items.Clear();

            string SUM = "SUM(CASE WHEN db_owner.Copy.Reader IS NULL THEN 1 ELSE 0 END) AS Available";

            DataTable dt = database.GetJoinedDataTable(ControllerDB.Table.Copy,
                ControllerDB.Table.Book, new string[] { "Copy.ISBN", "Title", "Author", SUM },
                "Copy.ISBN, Title, Author", new string[] { "db_owner.Book.ISBN = db_owner.Copy.ISBN" });





            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string isbnstr = dr["ISBN"].ToString();
                ListViewItem listitem = new ListViewItem(isbnstr);
                listitem.SubItems.Add(dr["Author"].ToString());
                listitem.SubItems.Add(dr["Title"].ToString());
                listitem.SubItems.Add(dr["Available"].ToString());
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
