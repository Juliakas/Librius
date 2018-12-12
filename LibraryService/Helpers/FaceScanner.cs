using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryService.Helpers
{
    public class FaceScanner
    {
        const string subscriptionKey = "<API_KEY>";
        const string uriBase = "https://northeurope.api.cognitive.microsoft.com/face/v1.0/";
        const string GroupId = "test_group";
        HttpClient Client { get; set; }

        public FaceScanner()
        {
            Client = new HttpClient();

            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        public async Task<string> DetectAsync(byte[] byteData)
        {
            string parameters = "returnFaceId=true";
            string uriDir = "detect";
            string uri = uriBase + uriDir + "?" + parameters;

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                HttpResponseMessage response = await Client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();
                return contentString;
            }
        } 

        public async Task<string> CreatePersonAsync(string id, byte[] byteData)
        {
            string uriDir = "persongroups/" + GroupId + "/persons";
            string uri = uriBase + uriDir;

            var name = new { name = id };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(name), Encoding.UTF8, "application/json");
            string c = await content.ReadAsStringAsync();
            HttpResponseMessage response = await Client.PostAsync(uri, content);

            string contentString = await response.Content.ReadAsStringAsync();
            PersonID _id = JsonConvert.DeserializeObject<PersonID>(contentString);

            uri += "/" + _id.personId + "/persistedfaces";

            using (ByteArrayContent byteContent = new ByteArrayContent(byteData))
            {
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                response = await Client.PostAsync(uri, byteContent);

                contentString = await response.Content.ReadAsStringAsync();

                uri = uriBase + "persongroups/" + GroupId + "/train";
                response = await Client.PostAsync(uri, new StringContent(""));
                Console.WriteLine();
                return contentString;
            }
        }

        public async Task<string> Identify(byte[] byteData)
        {
            string data = await DetectAsync(byteData);

            FaceID[] id = JsonConvert.DeserializeObject<FaceID[]>(data);

            if(id.Length == 0)
            {
                return "";
            }

            IdentificationDTO idDTO = new IdentificationDTO();
            idDTO.maxNumOfCandidatesReturned = 1;
            idDTO.personGroupId = GroupId;
            idDTO.faceIds[0] = id[0].faceId;

            string uri = uriBase + "identify";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(idDTO), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await Client.PostAsync(uri, content);
            string contentString = await message.Content.ReadAsStringAsync();

            FaceID[] faceID = JsonConvert.DeserializeObject<FaceID[]>(contentString);

            if(faceID[0].candidates.Length == 0)
            {
                return "";
            }   

            uri = uriBase + "persongroups/" + GroupId + "/persons/" + faceID[0].candidates[0].personId;

            message = await Client.GetAsync(uri);

            contentString = await message.Content.ReadAsStringAsync();

            PersonID personId = JsonConvert.DeserializeObject<PersonID>(contentString);

            return personId.name;
        }
    }

    public class PersonID
    {
        public string personId { get; set; }
        public string name { get; set; }
    }

    public class FaceID
    {
        public string faceId { get; set; }
        public Candidate[] candidates = new Candidate[1];
    }

    public class Candidate
    {
        public string personId { get; set; }
        public double confidence { get; set; }
    }

    public class IdentificationDTO
    {
        public string personGroupId { get; set; }
        public string[] faceIds = new string[1];
        public int maxNumOfCandidatesReturned { get; set; }
    }
}