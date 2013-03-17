using NLog;
using System;
using Autofac;
using System.Linq;
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

            //Uncomment for SQL storage
            //builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.SQL.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces();

            //Uncomment for Azure table storage
            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Table.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(x => x.Name.EndsWith("Controller")).AsSelf().PropertiesAutowired();
            return builder.Build();
        }
    }
}