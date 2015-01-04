using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Linq;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.DocumentDb
{
    public class MealRepository : BaseRepository, IMealRepository, IDocumentDbRepository
    {
        private const string COLLECTION_NAME = "Meals";
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

        public IEnumerable<Common.Models.Meal> List()
        {
            using(var client = GetClient())
            {
                return client.CreateDocumentQuery<Common.Models.Meal>(GetCollection().DocumentsLink).AsEnumerable().ToList();
            }
        }

        public Common.Models.Meal GetById(Guid id)
        {
            using (var client = GetClient())
            {
                return client.CreateDocumentQuery<Common.Models.Meal>(GetCollection().DocumentsLink).Where(x => x.Id == id)
                    .AsEnumerable()
                    .FirstOrDefault();
            }
        }

        public void Create(Common.Models.Meal meal)
        {
            using (var client = GetClient())
            {
                client.CreateDocumentAsync(GetCollection().DocumentsLink, meal).Wait();
            }
        }

        public void Edit(Common.Models.Meal meal)
        {
            using (var client = GetClient())
            {
                var item = client.CreateDocumentQuery(GetCollection().DocumentsLink).Where(x => x.Id == meal.Id.ToString()).AsEnumerable().FirstOrDefault();
                client.ReplaceDocumentAsync(item.SelfLink, meal).Wait();
            }
        }

    }
}
