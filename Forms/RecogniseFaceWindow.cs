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

namespace MyLibrarian.Forms
{
    public partial class RecogniseFaceWindow : Form
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("api_key", "endpoint");

        string _imagePath = "";
        string _groupId = "";

        public RecogniseFaceWindow()
        {
            InitializeComponent();
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
                MessageBox.Show(ex.Message);
                return new Face[0];
            }
        }

        // load image for detection
        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var od = new OpenFileDialog())
            {
                od.Filter = "All files(*.*)|*.*";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = od.FileName;
                    facePictureBox.Load(_imagePath);
                }
            }
        }

        // Create a new PersonGroup in which new users will be added
        private async void createGroupButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (groupNameTextBox.Text == "")
                {
                    MessageBox.Show("Group name field is empty");
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

                    MessageBox.Show("Group successfully created");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Browse and choose a folder with personal images in it
        private void browseFolderButton_Click(object sender, EventArgs e)
        {
            using (var fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() == DialogResult.OK)
                    imageFolderTextBox.Text = fb.SelectedPath;
                else
                    imageFolderTextBox.Text = "";
            }
        }

        // Add a new user to the users list
        private async void addUserButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (_groupId == "")
                {
                    MessageBox.Show("No groups found");
                }
                else if (newUserTextBox.Text == "")
                {
                    MessageBox.Show("New user field is empty");
                }
                else if (imageFolderTextBox.Text == "")
                {
                    MessageBox.Show("No folder attached to the user");
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
                    MessageBox.Show("Person was successfully added");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Train PersonGroup using the provided images to increase precision in associating a face to a name
        private async void trainButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (_groupId == "")
                {
                    MessageBox.Show("Group was not created");
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

                    MessageBox.Show("Training successfully completed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                MessageBox.Show("Identification successfully completed");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
