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
    public partial class MainUserWindow : Form
    {
        private readonly int userId;
        private readonly string firstName;
        private readonly string lastName;
        ControllerDB database;
        AuthWindow previousWindow;

        public MainUserWindow(AuthWindow previousWindow, int userId)
        {
            InitializeComponent();

            this.userId = userId;
            this.previousWindow = previousWindow;
            database = ControllerDB.Instance;

            DataTable dt = database.GetDataTable(ControllerDB.Table.Reader);
            LINQ<DataRow> filter = new LINQ<DataRow>(dt.AsEnumerable());
            filter.Filter(row => Int32.Parse(row["ID"].ToString()) == userId);
            try
            {
                dt = filter.Collection.CopyToDataTable();
            }
            catch(ArgumentNullException ex)
            {
                dt.Clear();
            }

            firstName = dt.Rows[0]["Name"].ToString().Trim(new char[] { ' ' });
            lastName = dt.Rows[0]["Surname"].ToString().Trim(new char[] { ' ' });

            SessionLabel.Text += String.Format("{0:D7}\n{1} {2}", userId, firstName, lastName);

            PopulateTable();
        }

        private void PopulateTable()
        {
            CopyListView.View = View.Details;
            CopyListView.Items.Clear();

            DataTable dt = database.GetJoinedDataTable(ControllerDB.Table.Copy, 
                ControllerDB.Table.Book, "*");

            LINQ<DataRow> filter = new LINQ<DataRow>(dt.AsEnumerable());
            filter.Filter(row =>
            {
                if (row["Reader"].GetType() == Type.GetType("System.DBNull"))
                {
                    return false;
                }
                else
                {
                    return Int32.Parse(row["Reader"].ToString()) == userId
                        && row["ISBN"].ToString() == row["ISBN1"].ToString();
                }
            });
            try
            {
                dt = filter.Collection.CopyToDataTable();
            }
            catch (InvalidOperationException ex)
            {
                dt.Clear();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["Author"].ToString());
                listitem.SubItems.Add(dr["Title"].ToString());
                listitem.SubItems.Add(dr["Borrowed"].ToString());
                CopyListView.Items.Add(listitem);
            }
        }



        private void LogOutButton_Click(object sender, EventArgs e)
        {
            previousWindow.Show();
            this.Dispose();
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {

        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {

        }
    }
}
