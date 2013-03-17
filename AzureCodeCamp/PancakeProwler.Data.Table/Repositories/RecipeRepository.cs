using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;
using Microsoft.WindowsAzure.Storage.Table;
using PancakeProwler.Data.Common.Repositories;
using PancakeProwler.Data.Table.TableEntities;

namespace PancakeProwler.Data.Table.Repositories
{
    public class RecipeRepository : BaseRepository, ITableStorageRepository, IRecipeRepository
    {
        private const string TABLE_NAME = "recipes";
        public void InitTableStorage()
        {
            CreateTable(TABLE_NAME);
        }

        public IEnumerable<Recipe> List()
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            TableQuery<RecipeTableEntity> query = new TableQuery<RecipeTableEntity>();
            var results = table.ExecuteQuery(query);

            return AutoMapper.Mapper.Map<IEnumerable<RecipeTableEntity>, IEnumerable<Recipe>>(results);
        }

        public Recipe GetById(Guid id)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            TableOperation retrieveOperation = TableOperation.Retrieve<RecipeTableEntity>("recipe", id.ToString());

            
            var result = table.Execute(retrieveOperation);

            return AutoMapper.Mapper.Map<RecipeTableEntity, Recipe>((RecipeTableEntity)result.Result);
        }

        public void Create(Recipe recipe)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var toInsert = AutoMapper.Mapper.Map<Recipe, RecipeTableEntity>(recipe);
            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(toInsert);

            table.Execute(insertOrReplaceOperation);

        }

        public void Edit(Recipe recipe)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var toInsert = AutoMapper.Mapper.Map<Recipe, RecipeTableEntity>(recipe);
            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(toInsert);

            table.Execute(insertOrReplaceOperation);
        }

        public void Dispose()
        {

        }
    }
}
