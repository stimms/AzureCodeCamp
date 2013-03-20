using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.SQL.Repositories
{
    public class MealRepository : IMealRepository
    {
        private DataContext _dataContext;

        public MealRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Common.Models.Meal> List()
        {
            return _dataContext.Meals.ToList();
        }

        public void Create(Common.Models.Meal meal)
        {
            _dataContext.Meals.Add(meal);
            _dataContext.SaveChanges();
        }

        public void Edit(Common.Models.Meal meal)
        {
            _dataContext.Entry(meal).State = System.Data.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public Common.Models.Meal GetById(Guid id)
        {
            return _dataContext.Meals.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}