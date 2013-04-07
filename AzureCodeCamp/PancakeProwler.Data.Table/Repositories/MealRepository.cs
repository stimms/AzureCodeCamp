using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;
using Microsoft.WindowsAzure.Storage.Table;
using PancakeProwler.Data.Common.Repositories;
using PancakeProwler.Data.Table.TableEntities;

namespace PancakeProwler.Data.Table.Repositories
{
    class MealRepository : BaseRepository, IMealRepository, ITableStorageRepository
    {
        private const string TABLE_NAME = "meal";
        public IEnumerable<Meal> List()
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var query = new TableQuery<MealTableEntity>();
            var results = table.ExecuteQuery(query);

            return AutoMapper.Mapper.Map<IEnumerable<MealTableEntity>, IEnumerable<Meal>>(results);
        }

        public Meal GetById(Guid id)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            TableOperation retrieveOperation = TableOperation.Retrieve<MealTableEntity>(TABLE_NAME , id.ToString());


            var result = table.Execute(retrieveOperation);

            return AutoMapper.Mapper.Map<MealTableEntity, Meal>((MealTableEntity)result.Result);
        }

        public void Create(Meal meal)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var toInsert = AutoMapper.Mapper.Map<Meal, MealTableEntity>(meal);
            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(toInsert);

            table.Execute(insertOrReplaceOperation);
        }

        public void Edit(Meal meal)
        {
            var tableClient = GetClient();

            CloudTable table = tableClient.GetTableReference(TABLE_NAME);

            var toInsert = AutoMapper.Mapper.Map<Meal, MealTableEntity>(meal);
            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(toInsert);

            table.Execute(insertOrReplaceOperation);
        }

        public void Dispose()
        {
        }

        public void InitTableStorage()
        {
            CreateTable(TABLE_NAME);
        }
    }
}
