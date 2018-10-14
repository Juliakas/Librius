namespace MyLibrarian.Forms
{
    partial class RecogniseFaceWindow
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
            this.facePictureBox = new System.Windows.Forms.PictureBox();
            this.createGroupLabel = new System.Windows.Forms.Label();
            this.groupNameLabel = new System.Windows.Forms.Label();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.createGroupButton = new System.Windows.Forms.Button();
            this.newUserLabel = new System.Windows.Forms.Label();
            this.newUserTextBox = new System.Windows.Forms.TextBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.imageFolderLabel = new System.Windows.Forms.Label();
            this.imageFolderTextBox = new System.Windows.Forms.TextBox();
            this.browseFolderButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.identifyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.identifiedUserListBox = new System.Windows.Forms.ListBox();
            this.addNewUserLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.takePictureButton = new System.Windows.Forms.Button();
            this.browseSaveButton = new System.Windows.Forms.Button();
            this.folderSaveTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.imageNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // facePictureBox
            // 
            this.facePictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.facePictureBox.Location = new System.Drawing.Point(27, 90);
            this.facePictureBox.Name = "facePictureBox";
            this.facePictureBox.Size = new System.Drawing.Size(490, 410);
            this.facePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.facePictureBox.TabIndex = 0;
            this.facePictureBox.TabStop = false;
            // 
            // createGroupLabel
            // 
            this.createGroupLabel.AutoSize = true;
            this.createGroupLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createGroupLabel.Location = new System.Drawing.Point(537, 20);
            this.createGroupLabel.Name = "createGroupLabel";
            this.createGroupLabel.Size = new System.Drawing.Size(137, 27);
            this.createGroupLabel.TabIndex = 1;
            this.createGroupLabel.Text = "Create group";
            // 
            // groupNameLabel
            // 
            this.groupNameLabel.AutoSize = true;
            this.groupNameLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNameLabel.Location = new System.Drawing.Point(546, 75);
            this.groupNameLabel.Name = "groupNameLabel";
            this.groupNameLabel.Size = new System.Drawing.Size(106, 22);
            this.groupNameLabel.TabIndex = 2;
            this.groupNameLabel.Text = "Group name";
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNameTextBox.Location = new System.Drawing.Point(665, 72);
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(173, 30);
            this.groupNameTextBox.TabIndex = 3;
            // 
            // createGroupButton
            // 
            this.createGroupButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createGroupButton.Location = new System.Drawing.Point(550, 117);
            this.createGroupButton.Name = "createGroupButton";
            this.createGroupButton.Size = new System.Drawing.Size(132, 42);
            this.createGroupButton.TabIndex = 4;
            this.createGroupButton.Text = "Create group";
            this.createGroupButton.UseVisualStyleBackColor = true;
            this.createGroupButton.Click += new System.EventHandler(this.createGroupButton_ClickAsync);
            // 
            // newUserLabel
            // 
            this.newUserLabel.AutoSize = true;
            this.newUserLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserLabel.Location = new System.Drawing.Point(546, 239);
            this.newUserLabel.Name = "newUserLabel";
            this.newUserLabel.Size = new System.Drawing.Size(93, 22);
            this.newUserLabel.TabIndex = 5;
            this.newUserLabel.Text = "User name";
            // 
            // newUserTextBox
            // 
            this.newUserTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserTextBox.Location = new System.Drawing.Point(665, 236);
            this.newUserTextBox.Name = "newUserTextBox";
            this.newUserTextBox.Size = new System.Drawing.Size(173, 30);
            this.newUserTextBox.TabIndex = 6;
            // 
            // addUserButton
            // 
            this.addUserButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUserButton.Location = new System.Drawing.Point(550, 331);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(134, 42);
            this.addUserButton.TabIndex = 7;
            this.addUserButton.Text = "Add user";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_ClickAsync);
            // 
            // imageFolderLabel
            // 
            this.imageFolderLabel.AutoSize = true;
            this.imageFolderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageFolderLabel.Location = new System.Drawing.Point(546, 287);
            this.imageFolderLabel.Name = "imageFolderLabel";
            this.imageFolderLabel.Size = new System.Drawing.Size(115, 22);
            this.imageFolderLabel.TabIndex = 8;
            this.imageFolderLabel.Text = "Image Folder";
            // 
            // imageFolderTextBox
            // 
            this.imageFolderTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageFolderTextBox.Location = new System.Drawing.Point(665, 284);
            this.imageFolderTextBox.Name = "imageFolderTextBox";
            this.imageFolderTextBox.Size = new System.Drawing.Size(173, 30);
            this.imageFolderTextBox.TabIndex = 9;
            // 
            // browseFolderButton
            // 
            this.browseFolderButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFolderButton.Location = new System.Drawing.Point(845, 276);
            this.browseFolderButton.Name = "browseFolderButton";
            this.browseFolderButton.Size = new System.Drawing.Size(144, 44);
            this.browseFolderButton.TabIndex = 10;
            this.browseFolderButton.Text = "Browse folder";
            this.browseFolderButton.UseVisualStyleBackColor = true;
            this.browseFolderButton.Click += new System.EventHandler(this.browseFolderButton_Click);
            // 
            // trainButton
            // 
            this.trainButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButton.Location = new System.Drawing.Point(550, 443);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(134, 42);
            this.trainButton.TabIndex = 11;
            this.trainButton.Text = "Train group";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_ClickAsync);
            // 
            // identifyButton
            // 
            this.identifyButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identifyButton.Location = new System.Drawing.Point(548, 569);
            this.identifyButton.Name = "identifyButton";
            this.identifyButton.Size = new System.Drawing.Size(134, 42);
            this.identifyButton.TabIndex = 12;
            this.identifyButton.Text = "Identify image";
            this.identifyButton.UseVisualStyleBackColor = true;
            this.identifyButton.Click += new System.EventHandler(this.identifyButton_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "Identify image";
            // 
            // identifiedUserListBox
            // 
            this.identifiedUserListBox.FormattingEnabled = true;
            this.identifiedUserListBox.ItemHeight = 20;
            this.identifiedUserListBox.Location = new System.Drawing.Point(700, 558);
            this.identifiedUserListBox.Name = "identifiedUserListBox";
            this.identifiedUserListBox.Size = new System.Drawing.Size(277, 64);
            this.identifiedUserListBox.TabIndex = 14;
            // 
            // addNewUserLabel
            // 
            this.addNewUserLabel.AutoSize = true;
            this.addNewUserLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewUserLabel.Location = new System.Drawing.Point(537, 189);
            this.addNewUserLabel.Name = "addNewUserLabel";
            this.addNewUserLabel.Size = new System.Drawing.Size(145, 27);
            this.addNewUserLabel.TabIndex = 15;
            this.addNewUserLabel.Text = "Add new user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 27);
            this.label2.TabIndex = 16;
            this.label2.Text = "Train group to recognise images";
            // 
            // takePictureButton
            // 
            this.takePictureButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takePictureButton.Location = new System.Drawing.Point(181, 511);
            this.takePictureButton.Name = "takePictureButton";
            this.takePictureButton.Size = new System.Drawing.Size(175, 42);
            this.takePictureButton.TabIndex = 18;
            this.takePictureButton.Text = "Take a picture";
            this.takePictureButton.UseVisualStyleBackColor = true;
            this.takePictureButton.Click += new System.EventHandler(this.takePictureButton_Click);
            // 
            // browseSaveButton
            // 
            this.browseSaveButton.Location = new System.Drawing.Point(344, 558);
            this.browseSaveButton.Name = "browseSaveButton";
            this.browseSaveButton.Size = new System.Drawing.Size(140, 37);
            this.browseSaveButton.TabIndex = 19;
            this.browseSaveButton.Text = "Browse folder";
            this.browseSaveButton.UseVisualStyleBackColor = true;
            this.browseSaveButton.Click += new System.EventHandler(this.browseSaveButton_Click);
            // 
            // folderSaveTextBox
            // 
            this.folderSaveTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderSaveTextBox.Location = new System.Drawing.Point(165, 566);
            this.folderSaveTextBox.Name = "folderSaveTextBox";
            this.folderSaveTextBox.Size = new System.Drawing.Size(173, 30);
            this.folderSaveTextBox.TabIndex = 20;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameTextBox.Location = new System.Drawing.Point(165, 607);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(173, 30);
            this.fileNameTextBox.TabIndex = 21;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(344, 602);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 37);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(61, 566);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(54, 20);
            this.folderLabel.TabIndex = 23;
            this.folderLabel.Text = "Folder";
            // 
            // imageNameLabel
            // 
            this.imageNameLabel.AutoSize = true;
            this.imageNameLabel.Location = new System.Drawing.Point(61, 610);
            this.imageNameLabel.Name = "imageNameLabel";
            this.imageNameLabel.Size = new System.Drawing.Size(98, 20);
            this.imageNameLabel.TabIndex = 24;
            this.imageNameLabel.Text = "Image name";
            // 
            // RecogniseFaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 645);
            this.Controls.Add(this.imageNameLabel);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.folderSaveTextBox);
            this.Controls.Add(this.browseSaveButton);
            this.Controls.Add(this.takePictureButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addNewUserLabel);
            this.Controls.Add(this.identifiedUserListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.identifyButton);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.browseFolderButton);
            this.Controls.Add(this.imageFolderTextBox);
            this.Controls.Add(this.imageFolderLabel);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.newUserTextBox);
            this.Controls.Add(this.newUserLabel);
            this.Controls.Add(this.createGroupButton);
            this.Controls.Add(this.groupNameTextBox);
            this.Controls.Add(this.groupNameLabel);
            this.Controls.Add(this.createGroupLabel);
            this.Controls.Add(this.facePictureBox);
            this.Name = "RecogniseFaceWindow";
            this.Text = "RecogniseFaceWindow";
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox facePictureBox;
        private System.Windows.Forms.Label createGroupLabel;
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.TextBox groupNameTextBox;
        private System.Windows.Forms.Button createGroupButton;
        private System.Windows.Forms.Label newUserLabel;
        private System.Windows.Forms.TextBox newUserTextBox;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Label imageFolderLabel;
        private System.Windows.Forms.TextBox imageFolderTextBox;
        private System.Windows.Forms.Button browseFolderButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button identifyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox identifiedUserListBox;
        private System.Windows.Forms.Label addNewUserLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button takePictureButton;
        private System.Windows.Forms.Button browseSaveButton;
        private System.Windows.Forms.TextBox folderSaveTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.Label imageNameLabel;
    }
}