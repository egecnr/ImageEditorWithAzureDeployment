using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;
using SixLabors.ImageSharp;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Runtime.CompilerServices;
using _641716_ServerSideAssignment.Service;
using _641716_ServerSideAssignment.Model;
using Azure.Storage.Queues;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Azure.Storage.Blobs.Models;

namespace _641716_ServerSideAssignment.blob
{
    public static class ImageEditBlob
    {
        [FunctionName("ImageEditBlob")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            try
            {
                BlobService blobService = new BlobService(Environment.GetEnvironmentVariable("BlobUploadName"));
                IFormFile imageInfo = req.Form.Files["Image"];
                ImageProperties img = new();
                img.imgId = Guid.NewGuid().ToString();
                log.LogInformation("Attempting to blob");

                BlobContentInfo blobcontent= await blobService.UploadBlob(imageInfo.OpenReadStream(), img.imgId);

                log.LogInformation($"{blobcontent.ContentHash}  {blobcontent.VersionId}");



                string qName = Environment.GetEnvironmentVariable("ColorHexQueue");     
                QueueService qService = new QueueService(qName);
                log.LogInformation("This is where everything broke");
                await qService.InsertDataToQueue(img);
                log.LogInformation("hehe hoho haha");


                return new OkObjectResult($"Image is edited and uploaded. Please use the following id to download the image: https://egehancinarlisspassignment.azurewebsites.net/api/ImageDownload?ImgId={img.imgId}");
            }
            catch (Exception e)
            {
                log.LogInformation($"{e.Message} / {e.StackTrace}");
                return new BadRequestObjectResult($"{e.Message} / {e.StackTrace}");
            }
        }

    }
}
