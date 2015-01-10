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
            //1. get client
            //2. query
            throw new NotImplementedException();
        }

        public Common.Models.Recipe GetById(Guid id)
        {
            //1. get client
            //2. query
            throw new NotImplementedException();
        }

        public void Create(Common.Models.Recipe recipe)
        {
            //1. get client
            //2. create document
        }

        public void Edit(Common.Models.Recipe recipe)
        {
            //1. get client
            //2. replace document
        }

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
    }
}
