using PancakeProwler.Data.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents.Client;
using PancakeProwler.Data.Common;

namespace PancakeProwler.Data.DocumentDb
{
    public class Configurator : IDataLayerConfigurator
    {
        public IEnumerable<IDocumentDbRepository> Repositories { get; set; }

        public void Configure()
        {
            CreateDatabase().Wait();
            foreach (var repository in Repositories)
            {
                try
                {
                    repository.InitDocumentDbStorage();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to initialize DocumentDb storage", ex);
                }
            }
        }
        private async Task CreateDatabase()
        {
            var client = new DocumentClient(new Uri(System.Configuration.ConfigurationManager.AppSettings["DocumentDbEndPoint"]),
                                                        System.Configuration.ConfigurationManager.AppSettings["DocumentDbAuthorizationKey"]);
            var database = client.CreateDatabaseQuery()
                                    .Where(db => db.Id == System.Configuration.ConfigurationManager.AppSettings["DocumentDbDatabaseName"])
                           .AsEnumerable()
                           .FirstOrDefault();
            if (database == null)
                await client.CreateDatabaseAsync(new Database { Id = "AzureCamp" });
        }
    }
}
