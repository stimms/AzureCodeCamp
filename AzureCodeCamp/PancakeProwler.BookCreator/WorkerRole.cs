using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.ServiceRuntime;


namespace PancakeProwler.BookCreator
{
    public class BookCreator : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("Starting book creator", "Information");
            
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("bookqueue");
            queue.CreateIfNotExists();
            
            while (true)
            {
                var message = queue.GetMessage();
                if (message != null)
                {
                    if(message.DequeueCount < 5)
                        SendCreationMessage(message);
                    queue.DeleteMessage(message);
                }
                else
                {
                    Thread.Sleep(new TimeSpan(0, 0, 0, 5));//5 seconds
                }
            }
        }


        private static void SendCreationMessage(Microsoft.WindowsAzure.Storage.Queue.CloudQueueMessage message)
        {
            var decodedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<PancakeProwler.Data.Common.Models.BookCreationRequest>(message.AsString);
            try
            {
                SendGridMail.SendGrid mailMessage = CreateEMailMessage(decodedMessage);
                SendMessage(mailMessage);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error sending: " + ex.Message, "Error");
            }
            Trace.WriteLine(decodedMessage.EMail, "Information");
        }
        private static SendGridMail.SendGrid CreateEMailMessage(PancakeProwler.Data.Common.Models.BookCreationRequest decodedMessage)
        {
            var mailMessage = SendGridMail.SendGrid.GetInstance();
            mailMessage.AddTo(decodedMessage.EMail);
            mailMessage.From = new System.Net.Mail.MailAddress("cookbook@pancakeprowler.com", "Pancake Prowler");
            mailMessage.Subject = "Cookbook Ready";
            mailMessage.Html = String.Format(@"Hello {0}, Your personalized cook book is available. To download it simply click <a href='{1}'>here</a>",
                                   decodedMessage.Name,
                                   new PdfCreator().GetCookBook(decodedMessage.Name));
            return mailMessage;
        }
        private static void SendMessage(SendGridMail.SendGrid mailMessage)
        {
            var credentials = new NetworkCredential("username", "password");
            var transportREST = SendGridMail.Web.GetInstance(credentials);
            transportREST.Deliver(mailMessage);
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
