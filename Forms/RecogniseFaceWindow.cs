using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using MyLibrarian.Forms.Utils;
using MyLibrarian.Data;

namespace MyLibrarian.Forms
{
    public partial class RecogniseFaceWindow : Form
    {

        string imagePath = "";
        string groupId = "";

        FaceRecognition faceRecognition;
        Webcam webcam;

        public RecogniseFaceWindow()
        {
            InitializeComponent();
            webcam = new Webcam(facePictureBox);
            webcam.cameraStart();
            faceRecognition = new FaceRecognition();

        }


        // Create a new PersonGroup in which new users will be added
        private async void createGroupButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (groupNameTextBox.Text == "")
                {
                    MessageManager.ShowMessageBox("Group name field is empty");
                }
                else
                {
                    groupId = groupNameTextBox.Text.ToLower().Replace(" ", "");

                    try
                    {
                        faceRecognition.createNewGroup(groupId, groupNameTextBox.Text);
                        MessageManager.ShowMessageBox("Group successfully created");
                    }
                    catch (Exception ex)
                    {
                        MessageManager.ShowMessageBox(ex);
                    }

                }
            }

            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex);
            }
        }

        // Browse and choose a folder with personal images in it
        private void browseFolderButton_Click(object sender, EventArgs e)
        {
            browse_folder(imageFolderTextBox);
        }

        private void browse_folder(TextBox textBox)
        {
            using (var fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() == DialogResult.OK)
                    textBox.Text = fb.SelectedPath;
                else
                    textBox.Text = "";
            }
        }

        // Add a new user to the users list
        private async void addUserButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (groupId == "")
                {
                    MessageManager.ShowMessageBox("No groups found");
                }
                else if (newUserTextBox.Text == "")
                {
                    MessageManager.ShowMessageBox("New user field is empty");
                }
                else if (imageFolderTextBox.Text == "")
                {
                    MessageManager.ShowMessageBox("No folder attached to the user");
                }
                else
                {
                    faceRecognition.addNewUser(newUserTextBox.Text.ToString(), imageFolderTextBox.Text, groupId);
                    MessageManager.ShowMessageBox("Person was successfully added");
                }

            }
            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex);
            }
        }

        // Train PersonGroup using the provided images to increase precision in associating a face to a name
        private async void trainButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (groupId == "")
                {
                    MessageManager.ShowMessageBox("Group was not created");
                }
                else
                {
                    faceRecognition.trainGroup(groupId);

                    MessageManager.ShowMessageBox("Training successfully completed");
                }
            }
            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex.Message);
            }
        }

        // recognise image
        private async void identifyButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(imagePath))
                {
                    faceRecognition.identifyUser(identifiedUserListBox, imagePath, groupId);
                    MessageManager.ShowMessageBox("Identification successfully completed");
                }
                else
                {
                    MessageManager.ShowMessageBox("Save your picture first");
                }

            }
            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex);
            }
        }

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            webcam.takePicture();

        }

        private void browseSaveButton_Click(object sender, EventArgs e)
        {
            browse_folder(folderSaveTextBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if ((fileNameTextBox.Text) != "" && (folderSaveTextBox.Text != ""))
            {
                if (!webcam.isCameraRunning())
                {
                    facePictureBox.Image.Save(folderSaveTextBox.Text + "//" + fileNameTextBox.Text + ".jpg", ImageFormat.Jpeg);
                    imagePath = folderSaveTextBox.Text + "//" + fileNameTextBox.Text + ".jpg";
                }
                else
                {
                    MessageBox.Show("Picture is not taken");
                }

            }
            else
            {
                MessageBox.Show("File name and folder fields must be filled");
            }

        }

        private void RecogniseFaceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcam.cameraStop();
        }
    }
}
