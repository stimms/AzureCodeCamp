using Autofac.Integration.Mvc;
using NLog;
using System;
using Autofac;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.SQL;

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
            builder.RegisterType<DataContext>().AsSelf().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(Data.SQL.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(Data.SQL.Repositories.MealRepository).Assembly).AsImplementedInterfaces().InstancePerHttpRequest();
            
            

            //Uncomment for Azure table storage
            //builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Table.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(x => x.Name.EndsWith("Controller")).AsSelf().PropertiesAutowired();
            return builder.Build();
        }
    }
}