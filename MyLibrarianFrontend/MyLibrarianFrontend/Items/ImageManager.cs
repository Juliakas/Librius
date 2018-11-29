using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace MyLibrarianFrontend.Items
{
    class ImageManager
    {
        public const string StorageConnectionString = "";
        private static CloudBlobContainer GetContainer()
        {

            var account = CloudStorageAccount.Parse(StorageConnectionString);
            var client = account.CreateCloudBlobClient();

     
            var container = client.GetContainerReference("my-librarian");

            return container;
        }

        public static async Task<string> UploadImage(Stream image, String userId)
        {
            var container = GetContainer();


            await container.CreateIfNotExistsAsync();

            var imageBlob = container.GetBlockBlobReference(userId);
            await imageBlob.UploadFromStreamAsync(image);

            return userId;
        }

    }
}