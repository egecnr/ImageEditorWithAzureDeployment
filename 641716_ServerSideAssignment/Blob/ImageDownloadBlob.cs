using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using _641716_ServerSideAssignment.Service;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage.Blobs.Specialized;

namespace _641716_ServerSideAssignment.Blob
{
    public static class ImageDownloadBlob
    {
        [FunctionName("ImageDownload")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string id = req.Query["ImgId"];
                BlobService blobUpdatedImagesService = new BlobService(Environment.GetEnvironmentVariable("BlobUpdateName"));
              
                    byte[] blobImageData = await blobUpdatedImagesService.DownloadBlob(id);
                    Uri uri = GetServiceSasUriForBlob(blobUpdatedImagesService.GetBlobClient(id));
                    return new OkObjectResult($"You can download the image from here: {uri}");
                
            }
            catch(Exception e)
            {
                log.LogInformation($"{e.Message} / {e.StackTrace}");
                return new BadRequestObjectResult($"{e.Message} {e.StackTrace}");
            }
           
       
        }
        private static Uri GetServiceSasUriForBlob(BlobClient blobClient,
            string storedPolicyName = null)
        {
            // Check whether this BlobClient object has been authorized with Shared Key.
            if (blobClient.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one hour.
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                    BlobName = blobClient.Name,
                    Resource = "b"
                };

                if (storedPolicyName == null)
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                    sasBuilder.SetPermissions(BlobSasPermissions.Read |
                        BlobSasPermissions.Write);
                }
                else
                {
                    sasBuilder.Identifier = storedPolicyName;
                }

                Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
                Console.WriteLine("SAS URI for blob is: {0}", sasUri);
                Console.WriteLine();

                return sasUri;
            }
            else
            {
                Console.WriteLine(@"BlobClient must be authorized with Shared Key 
                          credentials to create a service SAS.");
                return null;
            }
        }
    }

}
