using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using _641716_ServerSideAssignment.Model;
using _641716_ServerSideAssignment.publicapi;
using _641716_ServerSideAssignment.PublicApi;
using _641716_ServerSideAssignment.Service;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace _641716_ServerSideAssignment.Queue
{
    public class HexConverterQueue
    {
        //This queue trigger uses color api to convert hex values to color names and adds the updated image object to the new queue as a message.
        [FunctionName("HexConverterQueue")]
        public async static Task Run([QueueTrigger("color-name-queue", Connection = "AzureWebJobsStorage")]string imgJson, ILogger log)
        {
            try
            {
                ImageProperties img = JsonSerializer.Deserialize<ImageProperties>(imgJson);
                log.LogInformation($"Naming the hex codes of image: {img.imgId}");
                BlobService blobService = new BlobService(Environment.GetEnvironmentVariable("BlobUploadName"));
                byte[] blobData = await blobService.DownloadBlob(img.imgId);

                (byte[], string[]) hexes = ImageHelper.EditImage(blobData);
                img.colorHex1 = hexes.Item2[0];
                img.colorHex2 = hexes.Item2[1];

                BlobService blobUpdatedImagesService = new BlobService(Environment.GetEnvironmentVariable("BlobUpdateName"));

                HttpClient client = new HttpClient();
                img.color1 = await ColorApi.ConvertHexToColorName(img.colorHex1, client);
                img.color2 = await ColorApi.ConvertHexToColorName(img.colorHex2, client);

                img.colorText1 = await SongsterrApi.GetSongAndArtistName(img.color1, client);
                img.colorText2 = await SongsterrApi.GetSongAndArtistName(img.color2, client);

                string joinedImgText = img.colorText1 + "\n" + img.colorText2;
                log.LogInformation("");
                byte[] editedByteImageData = ImageHelper.AddTextToImage(hexes.Item1, (joinedImgText, (0f, 0f), 24, "FF0000"));
                log.LogInformation($"this is the image id: {img.imgId}");
                await blobUpdatedImagesService.UploadBlob(new MemoryStream(editedByteImageData), img.imgId);
                log.LogInformation($"function is completely called and this is the path id: " + img.imgId);
            }
            catch(Exception e)
            {
                log.LogInformation($"{e.Message} / {e.StackTrace}");
            }
           

        }
    }
}
