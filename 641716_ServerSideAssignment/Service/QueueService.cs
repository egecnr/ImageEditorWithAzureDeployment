using _641716_ServerSideAssignment.Model;
using Azure.Storage.Queues;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.Service
{
    public class QueueService
    {
        private string qName;
        private QueueClient qClient;
        private string connString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        private QueueClientOptions clientOpt= new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64, };
        public QueueService(string qName)
        {
            this.qName = qName;
            this.qClient = new(connString, qName,clientOpt);
        }
        public async Task InsertDataToQueue(ImageProperties image)
        {
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string imgJson = JsonSerializer.Serialize<ImageProperties>(image, opt);
            await qClient.SendMessageAsync(imgJson);
        }

    }
}
