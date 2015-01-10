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
            //1. get client
            //2. query table
            //3. map and return results
            throw new NotImplementedException();
        }

        public Recipe GetById(Guid id)
        {
            //1. get client
            //2. query table
            //3. map and return results
            throw new NotImplementedException();
        }

        public void Create(Recipe recipe)
        {
            //1. get client
            //2. insert

        }

        public void Edit(Recipe recipe)
        {
            //1. get client
            //2. insert
        }

        public void Dispose()
        {

        }
    }
}
