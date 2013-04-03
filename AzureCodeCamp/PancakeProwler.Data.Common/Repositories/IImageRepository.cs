using System;
using System.Collections.Generic;
using System.Linq;

namespace PancakeProwler.Data.Common.Repositories
{
    public interface IImageRepository
    {
        Uri Save(string contentType, int contentLength, System.IO.Stream inputStream);
    }
}
