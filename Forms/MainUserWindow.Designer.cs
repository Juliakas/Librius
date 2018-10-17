namespace MyLibrarian.Forms
{
    partial class MainUserWindow
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
            this.SessionLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.ReturnBookButton = new System.Windows.Forms.Button();
            this.CheckOutButton = new System.Windows.Forms.Button();
            this.CopyListView = new System.Windows.Forms.ListView();
            this.ListLabel = new System.Windows.Forms.Label();
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SessionLabel
            // 
            this.SessionLabel.AutoSize = true;
            this.SessionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionLabel.Location = new System.Drawing.Point(3, 0);
            this.SessionLabel.Name = "SessionLabel";
            this.SessionLabel.Size = new System.Drawing.Size(131, 20);
            this.SessionLabel.TabIndex = 0;
            this.SessionLabel.Text = "Current Session: ";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.SessionLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 48);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.LogOutButton);
            this.panel2.Controls.Add(this.ReturnBookButton);
            this.panel2.Controls.Add(this.CheckOutButton);
            this.panel2.Location = new System.Drawing.Point(367, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 353);
            this.panel2.TabIndex = 2;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.Location = new System.Drawing.Point(11, 293);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(178, 48);
            this.LogOutButton.TabIndex = 2;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // ReturnBookButton
            // 
            this.ReturnBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBookButton.Location = new System.Drawing.Point(11, 77);
            this.ReturnBookButton.Name = "ReturnBookButton";
            this.ReturnBookButton.Size = new System.Drawing.Size(178, 48);
            this.ReturnBookButton.TabIndex = 1;
            this.ReturnBookButton.Text = "Return book function";
            this.ReturnBookButton.UseVisualStyleBackColor = true;
            this.ReturnBookButton.Click += new System.EventHandler(this.ReturnBookButton_Click);
            // 
            // CheckOutButton
            // 
            this.CheckOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckOutButton.Location = new System.Drawing.Point(11, 12);
            this.CheckOutButton.Name = "CheckOutButton";
            this.CheckOutButton.Size = new System.Drawing.Size(178, 48);
            this.CheckOutButton.TabIndex = 0;
            this.CheckOutButton.Text = "Check out function";
            this.CheckOutButton.UseVisualStyleBackColor = true;
            this.CheckOutButton.Click += new System.EventHandler(this.CheckOutButton_Click);
            // 
            // CopyListView
            // 
            this.CopyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AuthorColumn,
            this.TitleColumn,
            this.DateColumn});
            this.CopyListView.Location = new System.Drawing.Point(12, 100);
            this.CopyListView.Name = "CopyListView";
            this.CopyListView.Size = new System.Drawing.Size(339, 241);
            this.CopyListView.TabIndex = 3;
            this.CopyListView.UseCompatibleStateImageBehavior = false;
            this.CopyListView.View = System.Windows.Forms.View.Details;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLabel.Location = new System.Drawing.Point(133, 77);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(90, 20);
            this.ListLabel.TabIndex = 1;
            this.ListLabel.Text = "Your books";
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Author";
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Due date";
            // 
            // MainUserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 353);
            this.Controls.Add(this.ListLabel);
            this.Controls.Add(this.CopyListView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainUserWindow";
            this.Text = "Library system";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SessionLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ReturnBookButton;
        private System.Windows.Forms.Button CheckOutButton;
        private System.Windows.Forms.ListView CopyListView;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
    }
}