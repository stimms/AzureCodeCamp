using System;
using System.Collections.Generic;
using System.Linq;

namespace PancakeProwler.Data.Common.Repositories
{
    public interface IImageRepository
    {
        Uri Save(string contentType, System.IO.Stream inputStream, string blobContainer = "");
    }
}
