using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.SQL.Repositories
{
    public class RecipeRepository : IRecipeRepository, IDisposable
    {
        private DataContext db = new DataContext();
        public IEnumerable<Common.Models.Recipe> List()
        {
            return db.Recipes.ToList();
        }

        public void Create(Common.Models.Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }

        public void Edit(Common.Models.Recipe recipe)
        {
            db.Entry(recipe).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public Common.Models.Recipe GetById(int id)
        {
            return db.Recipes.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
        }
        ~RecipeRepository()
        {
            Dispose(false);
        }



    }
}
