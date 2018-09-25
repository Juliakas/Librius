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
    public partial class BooksListWindow : Form
    {
        public BooksListWindow()
        {
            InitializeComponent();
            /*
            SqlCeDataReader dr;
            while(dr.Read())
            {
                ListViewItem book = new ListViewItem(dr["isbn"].toString());
                book.SubItems.Add(dr["author"].toString());
                book.SubItems.Add(dr["title"].toString());
                book.SubItems.Add(dr["date"].toString());
                bookListView.Items.Add(book);                
            }
            */
           
        }
    }
}
