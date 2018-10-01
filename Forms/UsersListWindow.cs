using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian
{
    public partial class UsersListWindow : Form
    {
        DataTable dt;
        ControllerDB database;
        public UsersListWindow()
        {
            InitializeComponent();
            database = AuthWindow.Instance.Database;

            PopulateTable();
        }
        
        private void PopulateTable()
        {
            userListView.View = View.Details;
            userListView.Items.Clear();
            dt = database.GetDataTableReader();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["ID"].ToString());
                listitem.SubItems.Add(dr["Vardas"].ToString());
                listitem.SubItems.Add(dr["Pavarde"].ToString());
                userListView.Items.Add(listitem);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < userListView.SelectedItems.Count; i++)
            {
                ListViewItem item = userListView.SelectedItems[i];
                string str = item.SubItems[0].Text;
                int id;
                Int32.TryParse(str, out id);

                database.DeleteFromReader(id);
                PopulateTable();
            }

        }
    }
}
