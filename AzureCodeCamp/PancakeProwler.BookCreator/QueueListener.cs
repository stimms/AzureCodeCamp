using System;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace PancakeProwler.BookCreator
{
    public class QueueListener : RoleEntryPoint
    {
        public override void Run()
        {
            Trace.WriteLine("Starting book creator", "Information");

            var queueClient = QueueClient.CreateFromConnectionString(System.Configuration.ConfigurationManager.AppSettings["ServiceBusEndPoint"], "demo");
            while (true)
            {
                var message = queueClient.Receive();
                if (message != null)
                {
                    var decodedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<PancakeProwler.Data.Common.Models.BookCreationRequest>(message.GetBody<string>());
                    var mailSender = new MailSender();
                    mailSender.SendCreationEMail(decodedMessage);
                    try
                    {
                        message.Complete();
                    }
                    catch(Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                    }
                }
            }

            //Uncomment for storage queue 
            //var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            //var storageQueueClient = storageAccount.CreateCloudQueueClient();
            //var queue = storageQueueClient.GetQueueReference("bookqueue");
            //queue.CreateIfNotExists();

            //while (true)
            //{
            //    var message = queue.GetMessage();
            //    if (message != null)
            //    {
            //        if (message.DequeueCount < 5)
            //  {
            //            var decodedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<PancakeProwler.Data.Common.Models.BookCreationRequest>(message.AsString);
            //            SendCreationEMail(decodedMessage);
            //  }
            //        queue.DeleteMessage(message);
            //    }
            //}
        }


        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
