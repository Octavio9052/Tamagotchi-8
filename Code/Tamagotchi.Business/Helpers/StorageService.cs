using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Tamagotchi.Business.Helpers
{
    public class StorageService
    {
        private readonly CloudBlobContainer _cloudImageContainer;
        private readonly CloudBlobContainer _cloudFilesContainer;
        private readonly CloudFileClient _cloudFileClient;

        public StorageService(string storageConnectionString)
        {
            if (!CloudStorageAccount.TryParse(storageConnectionString, out var storageAccount))
                throw new StorageException();

            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            var cloudBlobClient = storageAccount.CreateCloudBlobClient();

            // Create a container called 'quickstartblobs' and append a GUID value to it to make the name unique. 
            _cloudImageContainer = cloudBlobClient.GetContainerReference("images");
            _cloudImageContainer.CreateIfNotExistsAsync();

            _cloudFilesContainer = cloudBlobClient.GetContainerReference("files");
            _cloudFilesContainer.CreateIfNotExistsAsync();

            _cloudFileClient = storageAccount.CreateCloudFileClient();
        }

        public async Task<string> ProcessFileFromStream(Stream stream, string filename)
        {
            var cloudBlockBlob = _cloudFilesContainer.GetBlockBlobReference(filename);
            cloudBlockBlob.Properties.ContentType = "file";
            await cloudBlockBlob.UploadFromStreamAsync(stream);
            return cloudBlockBlob.Uri.ToString();
        }

        public async Task<string> LoadDll(string fileName)
        {
            var client = new WebClient();
            
            return null;
        }
    }
}