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
            //1. get client
            //2. query table
            //3. map and return results
            throw new NotImplementedException();
        }

        public Meal GetById(Guid id)
        {
            //1. get client
            //2. query table
            //3. map and return results
            throw new NotImplementedException();
        }

        public void Create(Meal meal)
        {
            //1. get client
            //2. insert
        }

        public void Edit(Meal meal)
        {
            //1. get client
            //2. update
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
