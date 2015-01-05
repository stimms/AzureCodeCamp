using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.ServiceBus.Messaging;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.ServiceBus.Repositories
{
    public class BookCreationRequestRepository : IBookCreationRequestRepository
    {
        public void Add(Common.Models.BookCreationRequest request)
        {
            var queueClient = QueueClient.CreateFromConnectionString(System.Configuration.ConfigurationManager.AppSettings["ServiceBusEndPoint"], "demo");
            queueClient.Send(new BrokeredMessage(Newtonsoft.Json.JsonConvert.SerializeObject(request)));
            
        }
    }
}
