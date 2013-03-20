using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;

namespace PancakeProwler.Data.Common.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> List();
        Recipe GetById(Guid id);
        void Create(Recipe recipe);
        void Edit(Recipe recipe);
    }
}
