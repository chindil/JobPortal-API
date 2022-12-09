using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.StaticFiles;
using Stx.Shared.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Shared.Api.Services
{
    public class BlobStorageService : IBlobStorageService
    {

        private BlobServiceClient _blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public BlobModel GetBlobContent(string containerName, string blobFileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobFileName);
                       
            return new BlobModel()
            {
                Name = blobFileName,
                ContentType = blobClient.GetProperties().Value.ContentType,
                Content = blobClient.OpenRead()
            };
        }

        public async Task<bool> UploadFileToStorage(Stream fileContent, string containerName, 
            string blobFileName, bool isOverride, string oldFileNameToDelete
            //string storageSharedKeyAccountName, string storageSharedKeyAccountKey
            )
        {
            // Create StorageSharedKeyCredentials object by reading the values from the configuration (appsettings.json)
            //StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(storageSharedKeyAccountName, storageSharedKeyAccountKey);

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
                throw new ApplicationException($"The container '{containerName}' does not exists");
            if (!string.IsNullOrWhiteSpace(oldFileNameToDelete))
            {
                var blobDeleteClient = containerClient.GetBlobClient(oldFileNameToDelete);
                var delResponse = await blobDeleteClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            }

            var blobClient = containerClient.GetBlobClient(blobFileName);
            new FileExtensionContentTypeProvider().TryGetContentType(blobFileName, out string contentType);
            var options = new BlobUploadOptions() { HttpHeaders = new BlobHttpHeaders() { ContentType = contentType}};
            var response = await blobClient.UploadAsync(fileContent, options);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFileFromStorage(string containerName, string blobFileName
            //string storageSharedKeyAccountName, string storageSharedKeyAccountKey
            )
        {
            // Create StorageSharedKeyCredentials object by reading the values from the configuration (appsettings.json)
            //StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(storageSharedKeyAccountName, storageSharedKeyAccountKey);

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
                throw new ApplicationException($"The container '{containerName}' does not exists");

            BlobClient blobClient = containerClient.GetBlobClient(blobFileName);
            return await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        #region REMOVED CODE (FOR CONTAINERS)
        //public IEnumerable<StorageContainerModel> GetContainers()
        //{
        //    Pageable<BlobContainerItem> response = _blobServiceClient.GetBlobContainers();

        //    return response.Select(c => new StorageContainerModel() { Name = c.Name });
        //}

        //public void CreateContainer(string containerName)
        //{
        //    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        //    if (containerClient.Exists())
        //        throw new ApplicationException($"Unable to create container '{containerName}' as it already exists");

        //    containerClient.Create();
        //}

        //public void DeleteContainer(string containerName)
        //{
        //    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        //    if (!containerClient.Exists())
        //        throw new ApplicationException($"Unable to delete container '{containerName}' as it does not exists");

        //    containerClient.Delete();
        //}

        //public IEnumerable<BlobInfoModel> ListBlobsInContainer(string containerName)
        //{
        //    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        //    if (!containerClient.Exists())
        //        throw new ApplicationException($"Cannot list blobs in container '{containerName}' as it does not exists");

        //    Pageable<BlobItem> blobs = containerClient.GetBlobs();
        //    var models = blobs.Select(b => new BlobInfoModel()
        //    {
        //        Name = b.Name,
        //        Tags = b.Tags,
        //        ContentEncoding = b.Properties.ContentEncoding,
        //        ContentType = b.Properties.ContentType,
        //        Size = b.Properties.ContentLength,
        //        CreatedOn = b.Properties.CreatedOn,
        //        AccessTier = b.Properties.AccessTier?.ToString(),
        //        BlobType = b.Properties.BlobType?.ToString()
        //    });

        //    return models;
        //} 
        #endregion

    }
}
