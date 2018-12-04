using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Face;
using System.Threading.Tasks;

namespace LibraryService.Helpers
{
    public class FaceRecognition
    {
        private readonly IFaceServiceClient faceServiceClient;

        string endpoint, key;

        public FaceRecognition()
        {
            faceServiceClient = new FaceServiceClient(key, endpoint);
        }

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
            catch (Exception)
            {
                return new Face[0];
            }
        }
        
        public async void CreateNewGroup(string groupId, string groupName)
        {
            await faceServiceClient.DeletePersonGroupAsync(groupId);
            await faceServiceClient.CreatePersonGroupAsync(groupId, groupName);
        }
        
        public async void AddNewUser(string newUserName, string imagesFolderPath, string groupId)
        {
            CreatePersonResult person = await faceServiceClient.CreatePersonInPersonGroupAsync(groupId, newUserName);

            foreach (string imagePath in Directory.GetFiles(imagesFolderPath))
            {
                using (Stream s = File.OpenRead(imagePath))
                {
                    await faceServiceClient.AddPersonFaceInPersonGroupAsync(groupId, person.PersonId, s);
                }
            }
        }
        
        public async void TrainGroup(string groupId)
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
        
        public async void IdentifyUser(string imagePath, string groupId)
        {
            Face[] faces = await UploadAndDetectFaces(imagePath);
            var faceIds = faces.Select(face => face.FaceId).ToArray();

            foreach (var identifyResult in await faceServiceClient.IdentifyAsync(groupId, faceIds))
            {
                if (identifyResult.Candidates.Length != 0)
                {
                    var candidateId = identifyResult.Candidates[0].PersonId;
                    var person = await faceServiceClient.GetPersonInPersonGroupAsync(groupId, candidateId);
                }
            }
        }
    }
}