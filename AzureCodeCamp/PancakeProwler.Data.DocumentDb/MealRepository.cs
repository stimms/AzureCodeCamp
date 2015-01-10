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
            //1. get client
            //2. create collection if it doesn't exist
            throw new NotImplementedException();
        }

        private DocumentCollection GetCollection()
        {
            //1. get client
            //2. get collection
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Models.Meal> List()
        {
            //1. get client
            //2. query
            throw new NotImplementedException();
        }

        public Common.Models.Meal GetById(Guid id)
        {
            //1. get client
            //2. query
            throw new NotImplementedException();
        }

        public void Create(Common.Models.Meal meal)
        {
            //1. get client
            //2. create document
        }

        public void Edit(Common.Models.Meal meal)
        {
            //1. get client
            //2. replace document
        }

    }
}
