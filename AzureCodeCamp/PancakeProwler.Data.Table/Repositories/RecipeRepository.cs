using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;
using PancakeProwler.Data.Table.TableEntities;
using PancakeProwler.Data.Common.Models;
using System.Collections;

namespace PancakeProwler.Data.Table.Repositories
{
    public class RecipeRepository : BaseRepository, ITableStorageRepository, IRecipeRepository
    {
        private const string TABLE_NAME = "recipes";
        public void InitTableStorage()
        {
            CreateTable(TABLE_NAME);
        }

        public IEnumerable<Common.Models.Recipe> List()
        {

            var tableClient = GetClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<RecipeTableEntity> query = new TableQuery<RecipeTableEntity>();
            var results = table.ExecuteQuery(query);

            return AutoMapper.Mapper.Map<IEnumerable<RecipeTableEntity>, IEnumerable<Recipe>>(results);
            //.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"));
        }

        public Common.Models.Recipe GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(Common.Models.Recipe recipe)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var toInsert = AutoMapper.Mapper.Map<Recipe, RecipeTableEntity>(recipe);
            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(toInsert);

            table.Execute(insertOrReplaceOperation);

        }

        public void Edit(Common.Models.Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
