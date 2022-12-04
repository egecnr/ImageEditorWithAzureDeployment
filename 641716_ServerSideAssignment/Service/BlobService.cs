using _641716_ServerSideAssignment.Model;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.KeyVault.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.Service
{
    public class BlobService
    {
        private string containerName;
        private BlobContainerClient blobClient;
        private string connString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

        public BlobService(string containerName)
        {
            this.containerName = containerName;
            blobClient = new(connString, containerName);
        }

        public BlobClient GetBlobClient(string name)
        {
            return this.blobClient.GetBlobClient(name);
        }

        public async Task<byte[]> DownloadBlob(string name)
        {
            BlobClient client = this.blobClient.GetBlobClient(name);
            var blobValue = await client.DownloadContentAsync();
            return blobValue.Value.Content.ToArray();

        }
        public async Task<BlobContentInfo> UploadBlob(Stream byteStream, string name)
        {
            BlobClient client = this.blobClient.GetBlobClient(name);
            var blobValue = await client.UploadAsync(byteStream);
            return blobValue.Value;
        }       
    }
}
