using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Linq;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.DocumentDb
{
    public class RecipeRepository : BaseRepository, IRecipeRepository, IDocumentDbRepository
    {
        private const string COLLECTION_NAME = "Recipes";

        public IEnumerable<Common.Models.Recipe> List()
        {
            using (var client = GetClient())
            {
                return client.CreateDocumentQuery<Common.Models.Recipe>(GetCollection().DocumentsLink).AsEnumerable().ToList();
            }
        }

        public Common.Models.Recipe GetById(Guid id)
        {
            using (var client = GetClient())
            {
                return client.CreateDocumentQuery<Common.Models.Recipe>(GetCollection().DocumentsLink).Where(x => x.Id == id)
                    .AsEnumerable()
                    .FirstOrDefault();
            }
        }

        public void Create(Common.Models.Recipe recipe)
        {
            using (var client = GetClient())
            {
                client.CreateDocumentAsync(GetCollection().DocumentsLink, recipe).Wait();
            }
        }

        public void Edit(Common.Models.Recipe recipe)
        {
            using (var client = GetClient())
            {
                var item = client.CreateDocumentQuery(GetCollection().DocumentsLink).Where(x => x.Id == recipe.Id.ToString())
                    .AsEnumerable()
                    .FirstOrDefault();
                client.ReplaceDocumentAsync(item.SelfLink, recipe).Wait();
            }
        }

        public async Task InitDocumentDbStorage()
        {
            using (var client = GetClient())
            {

                if (GetCollection() == null)
                {
                    var database = client.CreateDatabaseQuery().Where(db => db.Id == System.Configuration.ConfigurationManager.AppSettings["DocumentDbDatabaseName"])
                        .AsEnumerable()
                        .FirstOrDefault();
                    await client.CreateDocumentCollectionAsync(database.CollectionsLink, new DocumentCollection { Id = COLLECTION_NAME });
                }
            }
        }

        private DocumentCollection GetCollection()
        {
            using (var client = GetClient())
            {
                var database = client.CreateDatabaseQuery().Where(db => db.Id == System.Configuration.ConfigurationManager.AppSettings["DocumentDbDatabaseName"])
                    .AsEnumerable()
                    .FirstOrDefault();
                var collection = client.CreateDocumentCollectionQuery(database.CollectionsLink).Where(c => c.Id == COLLECTION_NAME)
                    .AsEnumerable()
                    .FirstOrDefault();
                return collection;
            }
        }
    }
}
