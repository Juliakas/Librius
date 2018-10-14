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

namespace MyLibrarian.Forms
{
    public partial class RecogniseFaceWindow : Form
    {
        FilterInfoCollection device;
        VideoCaptureDevice finalFrame;

        bool cameraIsRunning = true;

        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("api_key", "endpoint");

        string _imagePath = "";
        string _groupId = "";

        public RecogniseFaceWindow()
        {
            InitializeComponent();
            camera_start();
        }

        private void camera_start ()
        {
            device = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            finalFrame = new VideoCaptureDevice(device[0].MonikerString);
            finalFrame.Start();
            finalFrame.NewFrame += new AForge.Video.NewFrameEventHandler(newFrame_event);
        }

        private void newFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                facePictureBox.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {

            }

        }

        // read image as a stream and analize it by custom DetectAsync method
        private async Task<Face[]> UploadAndDetectFaces(string imageFilePath)
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream,
                        true,
                        true,
                        new FaceAttributeType[] {
                            FaceAttributeType.Gender,
                            FaceAttributeType.Age,
                            FaceAttributeType.Emotion,
                            FaceAttributeType.FacialHair,
                            FaceAttributeType.Glasses
                        });
                    return faces.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex);
                return new Face[0];
            }
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
                    _groupId = groupNameTextBox.Text.ToLower().Replace(" ", "");

                    try
                    {
                        await faceServiceClient.DeletePersonGroupAsync(_groupId);
                    }
                    catch { }

                    await faceServiceClient.CreatePersonGroupAsync(_groupId, groupNameTextBox.Text);

                    MessageManager.ShowMessageBox("Group successfully created");
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
                if (_groupId == "")
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
                    CreatePersonResult person = await faceServiceClient.CreatePersonAsync(_groupId, newUserTextBox.Text.ToString());

                    foreach (string imagePath in Directory.GetFiles(imageFolderTextBox.Text))
                    {
                        using (Stream s = File.OpenRead(imagePath))
                        {
                            await faceServiceClient.AddPersonFaceAsync(_groupId, person.PersonId, s);
                        }
                    }
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
                if (_groupId == "")
                {
                    MessageManager.ShowMessageBox("Group was not created");
                }
                else
                {
                    await faceServiceClient.TrainPersonGroupAsync(_groupId);

                    TrainingStatus trainingStatus = null;
                    while (true)
                    {
                        trainingStatus = await faceServiceClient.GetPersonGroupTrainingStatusAsync(_groupId);

                        if (trainingStatus.Status != Status.Running)
                        {
                            break;
                        }

                        await Task.Delay(1000);
                    }

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
                Face[] faces = await UploadAndDetectFaces(_imagePath);
                var faceIds = faces.Select(face => face.FaceId).ToArray();

                identifiedUserListBox.Items.Clear();

                foreach (var identifyResult in await faceServiceClient.IdentifyAsync(_groupId, faceIds))
                {
                    if (identifyResult.Candidates.Length != 0)
                    {
                        var candidateId = identifyResult.Candidates[0].PersonId;
                        var person = await faceServiceClient.GetPersonAsync(_groupId, candidateId);

                        identifiedUserListBox.Items.Add(person.Name);
                    }
                    else
                    {
                        identifiedUserListBox.Items.Add("< Unknown person >");
                    }

                }

                MessageManager.ShowMessageBox("Identification successfully completed");

            }
            catch (Exception ex)
            {
                MessageManager.ShowMessageBox(ex);
            }
        }

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            if (cameraIsRunning)
            {
                finalFrame.Stop();
                cameraIsRunning = false;
            }
            else
            {
                camera_start();
                cameraIsRunning = true;
            }
                
        }

        private void browseSaveButton_Click(object sender, EventArgs e)
        {
            browse_folder(folderSaveTextBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if ((fileNameTextBox.Text) != "" && (folderSaveTextBox.Text != ""))
            {
                if (!cameraIsRunning)
                {
                    facePictureBox.Image.Save(folderSaveTextBox.Text+ "//" +fileNameTextBox.Text+".jpg", ImageFormat.Jpeg);
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
            finalFrame.Stop();
        }
    }
}
