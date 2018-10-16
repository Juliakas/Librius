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
    public partial class AddCopyWindow : Form
    {
        private CopyListWindow previousWindow;
        private ControllerDB database;
        private readonly string isbn;

        public AddCopyWindow(CopyListWindow previousWindow, string isbn)
        {
            InitializeComponent();
            this.previousWindow = previousWindow;
            this.isbn = isbn;
            database = ControllerDB.Instance;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Int64 id = Int64.Parse(CopyIDBox.Text);
            database.InsertToCopy(new Copy(id, isbn));

            previousWindow.Show();
            previousWindow.PopulateTable();

            this.Dispose();
        }

        private void AddCopyWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousWindow.Show();
            this.Dispose();
        }
    }
}
