using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;

namespace PancakeProwler.Data.Common.Repositories
{
    public interface IBookCreationRequestRepository
    {
        void Add(BookCreationRequest request);
    }
}
