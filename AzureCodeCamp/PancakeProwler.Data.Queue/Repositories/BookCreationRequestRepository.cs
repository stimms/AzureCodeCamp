using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.Queue.Repositories
{
    public class BookCreationRequestRepository : IBookCreationRequestRepository
    {
        public void Add(PancakeProwler.Data.Common.Models.BookCreationRequest request)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("bookqueue");
            queue.CreateIfNotExists();

            var message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(request));
            queue.AddMessage(message);
            
        }
    }
}
