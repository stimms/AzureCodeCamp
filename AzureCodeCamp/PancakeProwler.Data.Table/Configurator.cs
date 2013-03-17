using System;
using System.Linq;
using PancakeProwler.Data.Common;
using System.Collections.Generic;

namespace PancakeProwler.Data.Table
{
    public class Configurator : IDataLayerConfigurator
    {
        public IEnumerable<Repositories.ITableStorageRepository> Repositories { get; set; }
        public void Configure()
        {
            AutoMapperConfigurer.Configure();
            foreach (var repository in Repositories)
            {
                repository.InitTableStorage();
            }
        }
    }
}
