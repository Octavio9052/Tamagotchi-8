﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Tamagotchi.Common.Exceptions;

namespace Tamagotchi.Business.Services
{
    public class CloudService
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobContainer _cloudImageContainer;
        private readonly CloudBlobContainer _cloudFilesContainer;
        string sourceFile = null;
        string destinationFile = null;
        private readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=tamagotchi9052;AccountKey=qRlBQq8RNJFNhP/DuNwk291Psu+LFle/xKNv7dbCYA+kA/nnOq+Z8JfZwQKFzjf0IDJCkxNijBypxG2ZEqAGnA==;EndpointSuffix=core.windows.net";

        public CloudService()
        {
            if (!CloudStorageAccount.TryParse(storageConnectionString, out _storageAccount)) throw new BusinessLayerExceptions();
            try
            {
                // Create the CloudBlobClient, endpoint for the storage account. (blob)
                var cloudBlobClient = _storageAccount.CreateCloudBlobClient();

                // Create a container called 'quickstartblobs' and append a GUID value to it to make the name unique. 
                _cloudImageContainer = cloudBlobClient.GetContainerReference("images");
                _cloudImageContainer.CreateIfNotExistsAsync();

                _cloudFilesContainer = cloudBlobClient.GetContainerReference("files");
                _cloudFilesContainer.CreateIfNotExistsAsync();
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
                var cloudBlockBlob = _cloudImageContainer.GetBlockBlobReference(filename);
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
                var cloudBlockBlob = _cloudFilesContainer.GetBlockBlobReference(filename);
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