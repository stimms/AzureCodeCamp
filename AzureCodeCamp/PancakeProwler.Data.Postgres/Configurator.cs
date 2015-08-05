using System.Collections.Generic;
using PancakeProwler.Data.Common;

namespace PancakeProwler.Data.Postgres
{
    public class Configurator : IDataLayerConfigurator
    {
        public IEnumerable<IPostgresRepository> Repositories { get; set; }
        public void Configure()
        {
            foreach (var repository in Repositories)
            {
                repository.InitPostgresStorage();
            }
        }
    }
}
