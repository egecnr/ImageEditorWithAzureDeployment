using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using _641716_ServerSideAssignment.Model;
using _641716_ServerSideAssignment.PublicApi;
using _641716_ServerSideAssignment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace _641716_ServerSideAssignment.Queue
{
    public class TextEditorQueue
    {
        /*[FunctionName("TextEditorQueue")]
        public async static Task Run([QueueTrigger("text-queue", Connection = "AzureWebJobsStorage")]string imgJson, ILogger log)
        {
            try
            {
                ImageProperties img = JsonSerializer.Deserialize<ImageProperties>(imgJson);
                log.LogInformation($"Finding text for colours {img.color1} and {img.color2}");

                HttpClient client = new HttpClient();

                img.colorText1 = await SongsterrApi.GetSongAndArtistName(img.color1, client);
                img.colorText2 = await SongsterrApi.GetSongAndArtistName(img.color2, client);

                log.LogInformation($"Found text for {img.color1} and {img.color2}  they are  {img.colorText1} and {img.colorText2}");

                //For retrieving original images
                BlobService blobOriginalImagesService = new BlobService(Environment.GetEnvironmentVariable("BlobUploadName"));
                //For inserting text-updated images
                BlobService blobUpdatedImagesService = new BlobService(Environment.GetEnvironmentVariable("BlobUpdateName"));
                string joinedImgText = img.colorText1 + "\n" + img.colorText2;
                byte[] blobImageData = await blobOriginalImagesService.DownloadBlob($"colorEditedImages/{img.imgId}");
                log.LogInformation($"{blobImageData.LongLength} byte array length");
                //I tried to pick a color that is easier to notice.

                byte[] editedByteImageData = ImageHelper.AddTextToImage(blobImageData, (joinedImgText, (0f, 0f), 24, "FF0000"));

                await blobUpdatedImagesService.UploadBlob(new MemoryStream(editedByteImageData), img.imgId);
                log.LogInformation($"we fucking called the upload here");
                log.LogInformation($"Image is edited and uploaded. Please use the following id to download the image: {img.imgId}");

            }
            catch(Exception e)
            {
                log.LogInformation($"{e.Message} / {e.StackTrace}");
            }
           

            */
        //}
    }
}
