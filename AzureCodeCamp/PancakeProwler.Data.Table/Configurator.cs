using System;
using System.Linq;
using PancakeProwler.Data.Common;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;

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
                try
                {
                    repository.InitTableStorage();
                }
                catch (StorageException ex)
                {
                    throw new Exception("Unable to initialize Azure storage. If you're running in a development environment then make sure that you have the storage emulator running. This can typically be done by typing 'storage emulator' into the windows search. If you're using Azure proper make sure that you have the correct endpoint listed in the configuration file.", ex);
                }
            }
        }
    }
}
