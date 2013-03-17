using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.Table.Repositories
{
    class MealRepository : BaseRepository, IMealRepository, ITableStorageRepository
    {
        public IEnumerable<Common.Models.Meal> List()
        {
            throw new NotImplementedException();
        }

        public Common.Models.Meal GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(Common.Models.Meal meal)
        {
            throw new NotImplementedException();
        }

        public void Edit(Common.Models.Meal meal)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public void InitTableStorage()
        {
            CreateTable("meal");
        }
    }
}
