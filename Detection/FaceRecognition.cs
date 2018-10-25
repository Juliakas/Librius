using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using MyLibrarian.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Data
{
    class FaceRecognition
    {
        private readonly IFaceServiceClient faceServiceClient;

        String endpoint, key;

        public FaceRecognition()
        {

            //System.Environment.SetEnvironmentVariable("APIKey", "value", EnvironmentVariableTarget.User);
            //var key = System.Environment.GetEnvironmentVariable("APIKey", EnvironmentVariableTarget.User);
            faceServiceClient = new FaceServiceClient(key, endpoint);

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
                return new Face[0];
            }
        }

        // Create a new PersonGroup in which new users will be added
        public async void createNewGroup(String groupId, String groupName)
        {

            await faceServiceClient.DeletePersonGroupAsync(groupId);
           

            await faceServiceClient.CreatePersonGroupAsync(groupId, groupName);

        }

        // Add a new user to the users list
        public async void addNewUser(String newUserName, String imagesFolderPath, String groupId)
        {
            CreatePersonResult person = await faceServiceClient.CreatePersonAsync(groupId, newUserName);

            foreach (string imagePath in Directory.GetFiles(imagesFolderPath))
            {
                using (Stream s = File.OpenRead(imagePath))
                {
                    await faceServiceClient.AddPersonFaceAsync(groupId, person.PersonId, s);
                }
            }
        }

        // Train PersonGroup using the provided images to increase precision in associating a face to a name
        public async void trainGroup(String groupId)
        {
            await faceServiceClient.TrainPersonGroupAsync(groupId);

            TrainingStatus trainingStatus = null;
            while (true)
            {
                trainingStatus = await faceServiceClient.GetPersonGroupTrainingStatusAsync(groupId);

                if (trainingStatus.Status != Status.Running)
                {
                    break;
                }
                await Task.Delay(1000);
            }
        }

        // recognise image
        public async void identifyUser(ListBox identifiedUserListBox, String imagePath, String groupId)
        {
            Face[] faces = await UploadAndDetectFaces(imagePath);
            var faceIds = faces.Select(face => face.FaceId).ToArray();

            identifiedUserListBox.Items.Clear();

            foreach (var identifyResult in await faceServiceClient.IdentifyAsync(groupId, faceIds))
            {
                if (identifyResult.Candidates.Length != 0)
                {
                    var candidateId = identifyResult.Candidates[0].PersonId;
                    var person = await faceServiceClient.GetPersonAsync(groupId, candidateId);

                    identifiedUserListBox.Items.Add(person.Name);
                }
                else
                {
                    identifiedUserListBox.Items.Add("< Unknown person >");
                }

            }
        }
    }
}
