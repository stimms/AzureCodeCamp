using PancakeProwler.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PancakeProwler.Data.Common.Repositories
{
    public interface IMealRepository : IDisposable
    {
        IEnumerable<Meal> List();
        Meal GetById(Guid id);
        void Create(Meal meal);
        void Edit(Meal meal);
    }
}
