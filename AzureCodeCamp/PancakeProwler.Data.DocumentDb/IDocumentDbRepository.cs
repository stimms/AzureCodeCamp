using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PancakeProwler.Data.DocumentDb
{
    public interface IDocumentDbRepository {
        Task InitDocumentDbStorage();
    }
}
