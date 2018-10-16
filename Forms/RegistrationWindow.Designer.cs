namespace MyLibrarian.Forms
{
    partial class RegistrationWindow
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
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordBox = new System.Windows.Forms.TextBox();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ShortPasswordLabel = new System.Windows.Forms.Label();
            this.PasswordDoesNotMatchLabel = new System.Windows.Forms.Label();
            this.BadPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameBox.ForeColor = System.Drawing.Color.Black;
            this.FirstNameBox.Location = new System.Drawing.Point(95, 50);
            this.FirstNameBox.MaxLength = 60;
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(170, 29);
            this.FirstNameBox.TabIndex = 0;
            this.FirstNameBox.Enter += new System.EventHandler(this.FirstNameBox_Enter);
            this.FirstNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstNameBox_KeyPress);
            this.FirstNameBox.Leave += new System.EventHandler(this.FirstNameBox_Leave);
            // 
            // LastNameBox
            // 
            this.LastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameBox.ForeColor = System.Drawing.Color.Black;
            this.LastNameBox.Location = new System.Drawing.Point(95, 105);
            this.LastNameBox.MaxLength = 60;
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(170, 29);
            this.LastNameBox.TabIndex = 1;
            this.LastNameBox.Enter += new System.EventHandler(this.LastNameBox_Enter);
            this.LastNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastNameBox_KeyPress);
            this.LastNameBox.Leave += new System.EventHandler(this.LastNameBox_Leave);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.Location = new System.Drawing.Point(95, 160);
            this.PasswordBox.MaxLength = 25;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.ShortcutsEnabled = false;
            this.PasswordBox.Size = new System.Drawing.Size(170, 29);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.Enter += new System.EventHandler(this.PasswordBox_Enter);
            this.PasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordBox_KeyPress);
            this.PasswordBox.Leave += new System.EventHandler(this.PasswordBox_Leave);
            // 
            // ConfirmPasswordBox
            // 
            this.ConfirmPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordBox.Location = new System.Drawing.Point(95, 215);
            this.ConfirmPasswordBox.MaxLength = 25;
            this.ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            this.ConfirmPasswordBox.ShortcutsEnabled = false;
            this.ConfirmPasswordBox.Size = new System.Drawing.Size(170, 29);
            this.ConfirmPasswordBox.TabIndex = 3;
            this.ConfirmPasswordBox.Enter += new System.EventHandler(this.ConfirmPasswordBox_Enter);
            this.ConfirmPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfirmPasswordBox_KeyPress);
            this.ConfirmPasswordBox.Leave += new System.EventHandler(this.ConfirmPasswordBox_Leave);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Location = new System.Drawing.Point(131, 275);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(101, 23);
            this.CreateAccountButton.TabIndex = 4;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = true;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(13, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(57, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ShortPasswordLabel
            // 
            this.ShortPasswordLabel.AutoSize = true;
            this.ShortPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.ShortPasswordLabel.Location = new System.Drawing.Point(87, 191);
            this.ShortPasswordLabel.Name = "ShortPasswordLabel";
            this.ShortPasswordLabel.Size = new System.Drawing.Size(189, 15);
            this.ShortPasswordLabel.TabIndex = 6;
            this.ShortPasswordLabel.Text = "At least 6 characters are required!";
            this.ShortPasswordLabel.Visible = false;
            // 
            // PasswordDoesNotMatchLabel
            // 
            this.PasswordDoesNotMatchLabel.AutoSize = true;
            this.PasswordDoesNotMatchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordDoesNotMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordDoesNotMatchLabel.Location = new System.Drawing.Point(112, 247);
            this.PasswordDoesNotMatchLabel.Name = "PasswordDoesNotMatchLabel";
            this.PasswordDoesNotMatchLabel.Size = new System.Drawing.Size(137, 15);
            this.PasswordDoesNotMatchLabel.TabIndex = 7;
            this.PasswordDoesNotMatchLabel.Text = "Passwords don\'t match!";
            this.PasswordDoesNotMatchLabel.Visible = false;
            // 
            // BadPasswordLabel
            // 
            this.BadPasswordLabel.AutoSize = true;
            this.BadPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.BadPasswordLabel.Location = new System.Drawing.Point(50, 191);
            this.BadPasswordLabel.Name = "BadPasswordLabel";
            this.BadPasswordLabel.Size = new System.Drawing.Size(269, 15);
            this.BadPasswordLabel.TabIndex = 6;
            this.BadPasswordLabel.Text = "Must contain one of each of these: (A-Z, a-z, 0-9)";
            this.BadPasswordLabel.Visible = false;
            // 
            // RegistrationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 361);
            this.Controls.Add(this.BadPasswordLabel);
            this.Controls.Add(this.PasswordDoesNotMatchLabel);
            this.Controls.Add(this.ShortPasswordLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CreateAccountButton);
            this.Controls.Add(this.ConfirmPasswordBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationWindow";
            this.Text = "RegistrationWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox ConfirmPasswordBox;
        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ShortPasswordLabel;
        private System.Windows.Forms.Label PasswordDoesNotMatchLabel;
        private System.Windows.Forms.Label BadPasswordLabel;
    }
}