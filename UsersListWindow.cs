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
        public UsersListWindow()
        {
            InitializeComponent();
            /*
            SqlCeDataReader dr;
            while(dr.Read())
            {
                ListViewItem user = new ListViewItem(dr["id"].toString());
                user.SubItems.Add(dr["firstName"].toString());
                user.SubItems.Add(dr["lastName"].toString());
                userListView.Items.Add(user);                
            }
            */
            
        }
    }
}
