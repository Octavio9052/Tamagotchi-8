using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Tamagotchi.Common.Exceptions;

namespace Tamagotchi.Business.Services
{
    public class CloudService
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobContainer _cloudImageContainer;
        private CloudBlobContainer _cloudFilesContainer;
        string sourceFile = null;
        string destinationFile = null;
        private string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=tamagotchi9052;AccountKey=qRlBQq8RNJFNhP/DuNwk291Psu+LFle/xKNv7dbCYA+kA/nnOq+Z8JfZwQKFzjf0IDJCkxNijBypxG2ZEqAGnA==;EndpointSuffix=core.windows.net";

        public CloudService()
        {
            if (!CloudStorageAccount.TryParse(storageConnectionString, out _storageAccount)) throw new BusinessLayerExceptions();
            try
            {
                // Create the CloudBlobClient, endpoint for the storage account. (blob)
                CloudBlobClient cloudBlobClient = this._storageAccount.CreateCloudBlobClient();

                // Create a container called 'quickstartblobs' and append a GUID value to it to make the name unique. 
                this._cloudImageContainer = cloudBlobClient.GetContainerReference("images");
                this._cloudImageContainer.CreateIfNotExistsAsync();

                this._cloudFilesContainer = cloudBlobClient.GetContainerReference("files");
                this._cloudFilesContainer.CreateIfNotExistsAsync();
            }
            catch (StorageException ex)
            {
                throw new BusinessLayerExceptions(ex);
            }
        }

        public async Task<string> ProcessImageFromStream(Stream stream, string filename)
        {
            try
            {
                CloudBlockBlob cloudBlockBlob = this._cloudImageContainer.GetBlockBlobReference(filename);
                cloudBlockBlob.Properties.ContentType = "image";
                await cloudBlockBlob.UploadFromStreamAsync(stream);
                return cloudBlockBlob.Uri.ToString();
            }
            catch (StorageException ex)
            {
                throw new BusinessLayerExceptions(ex);
            }
        }

        public async Task<string> ProcessFileFromStream(Stream stream, string filename)
        {
            try
            {
                CloudBlockBlob cloudBlockBlob = this._cloudFilesContainer.GetBlockBlobReference(filename);
                cloudBlockBlob.Properties.ContentType = "file";
                await cloudBlockBlob.UploadFromStreamAsync(stream);
                return cloudBlockBlob.Uri.ToString();
            }
            catch (StorageException ex)
            {
                throw new BusinessLayerExceptions(ex);
            }
        }
    }
}