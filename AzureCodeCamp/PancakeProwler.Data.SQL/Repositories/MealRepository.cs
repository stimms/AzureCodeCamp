using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.SQL.Repositories
{
    public class MealRepository:IMealRepository, IDisposable
    {
          private DataContext db = new DataContext();
        public IEnumerable<Common.Models.Meal> List()
        {
            return db.Meals.ToList();
        }

        public void Create(Common.Models.Meal meal)
        {
            db.Meals.Add(meal);
            db.SaveChanges();
        }

        public void Edit(Common.Models.Meal meal)
        {
            db.Entry(meal).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public Common.Models.Meal GetById(Guid id)
        {
            return db.Meals.Where(x => x.Id == id).SingleOrDefault();
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
        ~MealRepository()
        {
            Dispose(false);
        }

    }
}
