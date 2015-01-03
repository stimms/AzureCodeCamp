using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;

namespace PancakeProwler.Data.DocumentDb
{
    public class BaseRepository
    {
        protected DocumentClient GetClient()
        {
            var client = new DocumentClient(new Uri(System.Configuration.ConfigurationManager.AppSettings["DocumentDbEndPoint"]), System.Configuration.ConfigurationManager.AppSettings["DocumentDbAuthorizationKey"]);
            return client;
        }
    }
}
