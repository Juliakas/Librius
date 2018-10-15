namespace MyLibrarian.Forms
{
    partial class MainWindow
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
            this.isbnLabel = new System.Windows.Forms.Label();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.pDateLabel = new System.Windows.Forms.Label();
            this.showBooksButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.pDateTextBox = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isbnLabel.Location = new System.Drawing.Point(50, 37);
            this.isbnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(79, 19);
            this.isbnLabel.TabIndex = 6;
            this.isbnLabel.Text = "ISBN code";
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isbnTextBox.Location = new System.Drawing.Point(50, 58);
            this.isbnTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isbnTextBox.MaxLength = 13;
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(111, 23);
            this.isbnTextBox.TabIndex = 7;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLabel.Location = new System.Drawing.Point(50, 85);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(51, 19);
            this.authorLabel.TabIndex = 8;
            this.authorLabel.Text = "Author";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorTextBox.Location = new System.Drawing.Point(50, 105);
            this.authorTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(111, 23);
            this.authorTextBox.TabIndex = 9;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(50, 132);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(34, 19);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(50, 151);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(111, 23);
            this.titleTextBox.TabIndex = 11;
            // 
            // pDateLabel
            // 
            this.pDateLabel.AutoSize = true;
            this.pDateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDateLabel.Location = new System.Drawing.Point(50, 181);
            this.pDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pDateLabel.Name = "pDateLabel";
            this.pDateLabel.Size = new System.Drawing.Size(105, 19);
            this.pDateLabel.TabIndex = 12;
            this.pDateLabel.Text = "Publication date";
            // 
            // showBooksButton
            // 
            this.showBooksButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.showBooksButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBooksButton.Location = new System.Drawing.Point(110, 235);
            this.showBooksButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showBooksButton.Name = "showBooksButton";
            this.showBooksButton.Size = new System.Drawing.Size(78, 45);
            this.showBooksButton.TabIndex = 18;
            this.showBooksButton.Text = "Show all books";
            this.showBooksButton.UseVisualStyleBackColor = false;
            this.showBooksButton.Click += new System.EventHandler(this.showBooksButton_Click);
            // 
            // addBookButton
            // 
            this.addBookButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.addBookButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBookButton.Location = new System.Drawing.Point(25, 235);
            this.addBookButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(78, 44);
            this.addBookButton.TabIndex = 16;
            this.addBookButton.Text = "Add new book";
            this.addBookButton.UseVisualStyleBackColor = false;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // pDateTextBox
            // 
            this.pDateTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pDateTextBox.Location = new System.Drawing.Point(50, 199);
            this.pDateTextBox.Name = "pDateTextBox";
            this.pDateTextBox.Size = new System.Drawing.Size(111, 20);
            this.pDateTextBox.TabIndex = 19;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(220, 299);
            this.Controls.Add(this.pDateTextBox);
            this.Controls.Add(this.showBooksButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.pDateLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.isbnTextBox);
            this.Controls.Add(this.isbnLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MyLibrarian";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label pDateLabel;
        private System.Windows.Forms.Button showBooksButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.DateTimePicker pDateTextBox;
    }
}