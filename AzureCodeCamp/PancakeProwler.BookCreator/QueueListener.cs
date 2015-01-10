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

            //1. create queue client
            //2. poll for messages
            //3. act using mailSender.SendCreationEMail
          
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
