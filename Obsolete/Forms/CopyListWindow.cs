﻿using MyLibrarian.Data;
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
            database = ControllerDB.Instance;

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

        internal async void PopulateTable()
        {
            List<Copy> copies = await Copy.GetAll();

            var filteredList = from copy in copies
                               where copy.ISBN == isbn
                               select copy;

            CopyListView.View = View.Details;
            CopyListView.Items.Clear();
            foreach(var item in filteredList)
            {
                ListViewItem listitem = new ListViewItem(item.ID.ToString());
                if (item.Reader != 0)
                    listitem.SubItems.Add(item.Reader.ToString());
                else
                    listitem.SubItems.Add("");

                if (item.Borrowed != Convert.ToDateTime("1900-01-01"))
                {
                    listitem.SubItems.Add(item.Borrowed.ToShortDateString());
                }
                else
                {
                    listitem.SubItems.Add("-");
                }
                CopyListView.Items.Add(listitem);
            }
        }

        private async void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CopyListView.SelectedItems.Count; i++)
            {
                ListViewItem item = CopyListView.SelectedItems[i];
                int id = int.Parse(item.SubItems[0].Text);

                await DataProcessing.HttpManager.Instance.DeleteItemAsync(Convert.ToString(id), "Copies");
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
            this.Hide();
        }

        private void CopyListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackButton_Click(new object(), new EventArgs());
        }
    }
}
