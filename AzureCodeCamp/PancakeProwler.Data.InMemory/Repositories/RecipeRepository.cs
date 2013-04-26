using System;
using System.Linq;
using System.Collections.Generic;
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

        public void Edit(Recipe recipe)
        {
            var toRemove = _recipes.Where(x => x.Id == recipe.Id).FirstOrDefault();
            if (toRemove != null)
                _recipes.Remove(toRemove);
            _recipes.Add(recipe);
        }

        public Recipe GetById(Guid id)
        {
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

    }
}
