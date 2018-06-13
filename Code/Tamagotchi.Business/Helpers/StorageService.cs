using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace Tamagotchi.Business.Helpers
{
    class StorageService
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobContainer _cloudImageContainer;
        private CloudBlobContainer _cloudFilesContainer;
        string sourceFile = null;
        string destinationFile = null;

        public StorageService(string storageConnectionString)
        {
            if (!CloudStorageAccount.TryParse(storageConnectionString, out _storageAccount)) throw new StorageException();

            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient cloudBlobClient = this._storageAccount.CreateCloudBlobClient();

            // Create a container called 'quickstartblobs' and append a GUID value to it to make the name unique. 
            this._cloudImageContainer = cloudBlobClient.GetContainerReference("images");
            this._cloudImageContainer.CreateIfNotExistsAsync();

            this._cloudFilesContainer = cloudBlobClient.GetContainerReference("files");
            this._cloudFilesContainer.CreateIfNotExistsAsync();
        }

        public async Task<string> ProcessImageFromStream(Stream stream, string filename)
        {
            CloudBlockBlob cloudBlockBlob = this._cloudImageContainer.GetBlockBlobReference(filename);
            cloudBlockBlob.Properties.ContentType = "image";
            await cloudBlockBlob.UploadFromStreamAsync(stream);
            return cloudBlockBlob.Uri.ToString();
        }

        public async Task<string> ProcessFileFromStream(Stream stream, string filename)
        {
            CloudBlockBlob cloudBlockBlob = this._cloudFilesContainer.GetBlockBlobReference(filename);
            cloudBlockBlob.Properties.ContentType = "file";
            await cloudBlockBlob.UploadFromStreamAsync(stream);
            return cloudBlockBlob.Uri.ToString();
        }
    }
}
