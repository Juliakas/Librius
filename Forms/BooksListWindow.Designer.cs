﻿namespace MyLibrarian.Forms
{
    partial class BooksListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BookListView = new System.Windows.Forms.ListView();
            this.isbnColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pDateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ShowCopiesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookListView
            // 
            this.BookListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BookListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.isbnColumnHeader,
            this.authorColumnHeader,
            this.titleColumnHeader,
            this.pDateColumnHeader});
            this.BookListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.BookListView.Location = new System.Drawing.Point(0, 0);
            this.BookListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BookListView.Name = "BookListView";
            this.BookListView.Size = new System.Drawing.Size(600, 495);
            this.BookListView.TabIndex = 0;
            this.BookListView.UseCompatibleStateImageBehavior = false;
            this.BookListView.View = System.Windows.Forms.View.Details;
            // 
            // isbnColumnHeader
            // 
            this.isbnColumnHeader.Text = "ISBN code";
            this.isbnColumnHeader.Width = 130;
            // 
            // authorColumnHeader
            // 
            this.authorColumnHeader.Text = "Author";
            this.authorColumnHeader.Width = 161;
            // 
            // titleColumnHeader
            // 
            this.titleColumnHeader.Text = "Title";
            this.titleColumnHeader.Width = 192;
            // 
            // pDateColumnHeader
            // 
            this.pDateColumnHeader.Text = "Publication date";
            this.pDateColumnHeader.Width = 120;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(607, 82);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(82, 44);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // ShowCopiesButton
            // 
            this.ShowCopiesButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowCopiesButton.Location = new System.Drawing.Point(607, 12);
            this.ShowCopiesButton.Name = "ShowCopiesButton";
            this.ShowCopiesButton.Size = new System.Drawing.Size(82, 44);
            this.ShowCopiesButton.TabIndex = 3;
            this.ShowCopiesButton.Text = "Show copies";
            this.ShowCopiesButton.UseVisualStyleBackColor = true;
            this.ShowCopiesButton.Click += new System.EventHandler(this.ShowCopiesButton_Click);
            // 
            // BooksListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 495);
            this.Controls.Add(this.ShowCopiesButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.BookListView);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BooksListWindow";
            this.Text = "Books List ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BookListView;
        private System.Windows.Forms.ColumnHeader isbnColumnHeader;
        private System.Windows.Forms.ColumnHeader authorColumnHeader;
        private System.Windows.Forms.ColumnHeader titleColumnHeader;
        private System.Windows.Forms.ColumnHeader pDateColumnHeader;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ShowCopiesButton;
    }
}