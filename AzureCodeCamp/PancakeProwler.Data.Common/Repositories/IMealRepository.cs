using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;

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
