using Stx.Shared.Api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Stx.Shared.Api.Interfaces
{
    public interface IBlobStorageService
    {

        public BlobModel GetBlobContent(string containerName, string blobFileName);

        public Task<bool> UploadFileToStorage(Stream fileContent, 
            string containerName, 
            string blobFileName, bool isOverride,
            string oldFileNameToDelete = ""
            //string storageSharedKeyAccountName, string storageSharedKeyAccountKey
            );

        public Task<bool> DeleteFileFromStorage(
            string containerName, 
            string blobFileName
            //string storageSharedKeyAccountName, string storageSharedKeyAccountKey
            );

    }
}
