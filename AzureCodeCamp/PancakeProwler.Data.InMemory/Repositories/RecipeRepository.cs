using System;
using System.Collections.Generic;
using System.Linq;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.InMemory.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private IList<Recipe> _recipes;

        public RecipeRepository()
        {
            _recipes = new List<Recipe>();
        }


        public IEnumerable<Recipe> List()
        {
            return _recipes;
        }

        public void Create(Recipe recipe)
        {
            recipe.Id = Guid.NewGuid();
            _recipes.Add(recipe);
        }

        public void Edit(Common.Models.Recipe recipe)
        {
            //?
        }

        public Common.Models.Recipe GetById(Guid id)
        {
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

    }
}
