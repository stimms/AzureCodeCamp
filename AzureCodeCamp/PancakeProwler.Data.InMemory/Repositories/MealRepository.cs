using System;
using System.Collections.Generic;
using System.Linq;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.InMemory.Repositories
{
    public class MealRepository : IMealRepository
    {
        private IList<Meal> _meals;

        public MealRepository()
        {
            _meals = new List<Meal>();
        }

        public IEnumerable<Meal> List()
        {
            return _meals;
        }

        public Meal GetById(Guid id)
        {
            return _meals.FirstOrDefault(m => m.Id == id);
        }

        public void Create(Meal meal)
        {
            meal.Id = Guid.NewGuid();
            _meals.Add(meal);
        }

        public void Edit(Meal meal)
        {
            //?
        }
    }
}
