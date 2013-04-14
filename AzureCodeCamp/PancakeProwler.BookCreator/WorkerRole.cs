using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using PancakeProwler.Data.Common.Repositories;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


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
                    var decodedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<PancakeProwler.Data.Common.Models.BookCreationRequest>(message.AsString);

                    var mailMessage = SendGridMail.SendGrid.GetInstance();
                    mailMessage.AddTo(decodedMessage.EMail);
                    mailMessage.From = new System.Net.Mail.MailAddress("cookbook@pancakeprowler.com", "Pancake Prowler");
                    mailMessage.Subject = "Cookbook Ready";
                    mailMessage.Html = String.Format(@"Hello {0}, Your personalized cook book is available. To download it simply click <a href='{1}'>here</a>", decodedMessage.Name, GetCookBook(decodedMessage.Name));
                    

                    Trace.WriteLine(decodedMessage.EMail, "Information");
                    queue.DeleteMessage(message);
                }
                else
                {
                    Thread.Sleep(new TimeSpan(0, 0, 0, 5));//5 seconds
                }
                
            }
        }

        private Uri GetCookBook(string name)
        {
            var document = new PdfDocument();
            document.Info.Title = name + "'s personalized cookbook";
            document.Info.Author = "Pancake Prowler";

            var page = document.AddPage();

            var graphics = XGraphics.FromPdfPage(page);

            var font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            graphics.DrawString(name + "'s personalized cookbook", 
                font, 
                XBrushes.Red, 
                new System.Drawing.PointF((float)page.Width/2, (float)page.Height/2), 
                XStringFormat.Center);

            var saveStream = new MemoryStream();
            document.Save(saveStream);

            var memoryStream = new MemoryStream(saveStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            var imageStore = new BlobImageRepository();
            return imageStore.Save("application/pdf", memoryStream);
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
