namespace MyLibrarian.Forms
{
    partial class AuthWindow
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
            this.UserIdBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.AdminButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserIdBox
            // 
            this.UserIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIdBox.Location = new System.Drawing.Point(46, 58);
            this.UserIdBox.MaxLength = 7;
            this.UserIdBox.Name = "UserIdBox";
            this.UserIdBox.Size = new System.Drawing.Size(133, 23);
            this.UserIdBox.TabIndex = 0;
            this.UserIdBox.Text = "User ID";
            this.UserIdBox.Enter += new System.EventHandler(this.UserIdBox_Enter);
            this.UserIdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserIdBox_KeyPress);
            this.UserIdBox.Leave += new System.EventHandler(this.UserIdBox_Leave);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.Location = new System.Drawing.Point(46, 100);
            this.PasswordBox.MaxLength = 18;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(133, 23);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.Text = "Password";
            this.PasswordBox.Enter += new System.EventHandler(this.PasswordBox_Enter);
            this.PasswordBox.Leave += new System.EventHandler(this.PasswordBox_Leave);
            // 
            // LogInButton
            // 
            this.LogInButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LogInButton.Location = new System.Drawing.Point(76, 151);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 23);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(140, 12);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // AdminButton
            // 
            this.AdminButton.Location = new System.Drawing.Point(12, 12);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(75, 23);
            this.AdminButton.TabIndex = 4;
            this.AdminButton.Text = "Admin";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // AuthWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 206);
            this.Controls.Add(this.AdminButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserIdBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthWindow";
            this.Text = "Authentification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserIdBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button AdminButton;
    }
}