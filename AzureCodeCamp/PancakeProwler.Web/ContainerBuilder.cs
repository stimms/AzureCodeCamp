using NLog;
using System;
using Autofac;
using System.Linq;
using Autofac.Integration.Mvc;
using PancakeProwler.Data.SQL;
using System.Collections.Generic;

namespace PancakeProwler.Web
{
    public class ContainerBuilder
    {
        public IContainer BuildContainer(Logger log)
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterInstance(log);
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).AsImplementedInterfaces();

            //Uncomment for InMemory Storage
            builder.RegisterAssemblyTypes(typeof (PancakeProwler.Data.InMemory.Repositories.RecipeRepository).Assembly)
                   .AsImplementedInterfaces()
                   .SingleInstance();

            //Uncomment for SQL storage
            //builder.RegisterType<DataContext>().AsSelf().InstancePerHttpRequest();
            //builder.RegisterAssemblyTypes(typeof(Data.SQL.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().InstancePerHttpRequest();           

            //Uncomment for Azure table storage
            //builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Table.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Queue.Repositories.BookCreationRequestRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterType<PancakeProwler.Data.Common.Repositories.BlobImageRepository>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(x => x.Name.EndsWith("Controller")).AsSelf().PropertiesAutowired();
            return builder.Build();
        }
    }
}