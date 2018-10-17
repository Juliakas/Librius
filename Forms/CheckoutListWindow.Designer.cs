namespace MyLibrarian.Forms
{
    partial class CheckoutListWindow
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
            this.ISBNColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CopyListView
            // 
            this.CopyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CopyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ISBNColumn,
            this.AuthorColumn,
            this.TitleColumn,
            this.CountHeader});
            this.CopyListView.Location = new System.Drawing.Point(-1, 0);
            this.CopyListView.Name = "CopyListView";
            this.CopyListView.Size = new System.Drawing.Size(385, 319);
            this.CopyListView.TabIndex = 0;
            this.CopyListView.UseCompatibleStateImageBehavior = false;
            this.CopyListView.View = System.Windows.Forms.View.Details;
            // 
            // ISBNColumn
            // 
            this.ISBNColumn.Text = "ISBN";
            this.ISBNColumn.Width = 80;
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Author";
            this.AuthorColumn.Width = 110;
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            this.TitleColumn.Width = 130;
            // 
            // CountHeader
            // 
            this.CountHeader.Text = "Available";
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckoutButton.Location = new System.Drawing.Point(390, 12);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(96, 36);
            this.CheckoutButton.TabIndex = 1;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(390, 269);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(96, 36);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CheckoutListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 317);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CheckoutButton);
            this.Controls.Add(this.CopyListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckoutListWindow";
            this.Text = "CheckoutListWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CheckoutListWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView CopyListView;
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.ColumnHeader ISBNColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader CountHeader;
        private System.Windows.Forms.Button BackButton;
    }
}