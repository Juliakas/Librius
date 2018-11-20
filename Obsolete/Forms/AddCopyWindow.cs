using MyLibrarian.Data;
using MyLibrarian.DataProcessing;
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
        private HttpManager manager;
        private readonly string isbn;

        public AddCopyWindow(CopyListWindow previousWindow, string isbn)
        {
            InitializeComponent();
            this.previousWindow = previousWindow;
            this.isbn = isbn;
            database = ControllerDB.Instance;
            manager = HttpManager.Instance;
        }


        private async void AddButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(CopyIDBox.Text);
            await manager.PostItemAsync(new Copy(id, isbn));

            previousWindow.PopulateTable();
            previousWindow.Show();
            

            this.Dispose();
        }

        private void AddCopyWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousWindow.Show();
            this.Dispose();
        }
    }
}
