namespace MyLibrarian.Forms
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
            this.bookListView = new System.Windows.Forms.ListView();
            this.isbnColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pDateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookListView
            // 
            this.bookListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.isbnColumnHeader,
            this.authorColumnHeader,
            this.titleColumnHeader,
            this.pDateColumnHeader});
            this.bookListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.bookListView.Location = new System.Drawing.Point(0, 0);
            this.bookListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(603, 495);
            this.bookListView.TabIndex = 0;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            this.bookListView.View = System.Windows.Forms.View.Details;
            // 
            // isbnColumnHeader
            // 
            this.isbnColumnHeader.Text = "ISBN code";
            this.isbnColumnHeader.Width = 130;
            // 
            // authorColumnHeader
            // 
            this.authorColumnHeader.Text = "Author";
            this.authorColumnHeader.Width = 170;
            // 
            // titleColumnHeader
            // 
            this.titleColumnHeader.Text = "Title";
            this.titleColumnHeader.Width = 190;
            // 
            // pDateColumnHeader
            // 
            this.pDateColumnHeader.Text = "Publication date";
            this.pDateColumnHeader.Width = 120;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(606, 12);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(82, 44);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(606, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "New copy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(606, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Show all";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BooksListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 495);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.bookListView);
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

        private System.Windows.Forms.ListView bookListView;
        private System.Windows.Forms.ColumnHeader isbnColumnHeader;
        private System.Windows.Forms.ColumnHeader authorColumnHeader;
        private System.Windows.Forms.ColumnHeader titleColumnHeader;
        private System.Windows.Forms.ColumnHeader pDateColumnHeader;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}