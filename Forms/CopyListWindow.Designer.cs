namespace MyLibrarian.Forms
{
    partial class CopyListWindow
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
            this.CopyListView = new System.Windows.Forms.ListView();
            this.IdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReaderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BorrowedDataColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveButton = new System.Windows.Forms.Button();
            this.NewCopyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CopyListView
            // 
            this.CopyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CopyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumnHeader,
            this.ReaderColumnHeader,
            this.BorrowedDataColumnHeader});
            this.CopyListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CopyListView.Location = new System.Drawing.Point(0, 0);
            this.CopyListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CopyListView.Name = "CopyListView";
            this.CopyListView.Size = new System.Drawing.Size(413, 495);
            this.CopyListView.TabIndex = 0;
            this.CopyListView.UseCompatibleStateImageBehavior = false;
            this.CopyListView.View = System.Windows.Forms.View.Details;
            // 
            // IdColumnHeader
            // 
            this.IdColumnHeader.Text = "ID";
            this.IdColumnHeader.Width = 127;
            // 
            // ReaderColumnHeader
            // 
            this.ReaderColumnHeader.Text = "Reader";
            this.ReaderColumnHeader.Width = 163;
            // 
            // BorrowedDataColumnHeader
            // 
            this.BorrowedDataColumnHeader.Text = "Borrowed at";
            this.BorrowedDataColumnHeader.Width = 120;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(420, 82);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(82, 44);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // NewCopyButton
            // 
            this.NewCopyButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCopyButton.Location = new System.Drawing.Point(420, 12);
            this.NewCopyButton.Name = "NewCopyButton";
            this.NewCopyButton.Size = new System.Drawing.Size(82, 44);
            this.NewCopyButton.TabIndex = 2;
            this.NewCopyButton.Text = "New copy";
            this.NewCopyButton.UseVisualStyleBackColor = true;
            this.NewCopyButton.Click += new System.EventHandler(this.NewCopyButton_Click);
            // 
            // CopyListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 495);
            this.Controls.Add(this.NewCopyButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.CopyListView);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyListWindow";
            this.Text = "Books List ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView CopyListView;
        private System.Windows.Forms.ColumnHeader IdColumnHeader;
        private System.Windows.Forms.ColumnHeader ReaderColumnHeader;
        private System.Windows.Forms.ColumnHeader BorrowedDataColumnHeader;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button NewCopyButton;
    }
}