using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.SQL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private DataContext _dataContext;

        public RecipeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<Common.Models.Recipe> List()
        {
            return _dataContext.Recipes.ToList();
        }

        public void Create(Common.Models.Recipe recipe)
        {
            _dataContext.Recipes.Add(recipe);
            _dataContext.SaveChanges();
        }

        public void Edit(Common.Models.Recipe recipe)
        {
            _dataContext.Entry(recipe).State = System.Data.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public Common.Models.Recipe GetById(Guid id)
        {
            return _dataContext.Recipes.Where(x => x.Id == id).SingleOrDefault();
        }

    }
}
