using NLog;
using Autofac;
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

//            Uncomment for InMemory Storage
            builder.RegisterAssemblyTypes(typeof(Data.InMemory.Repositories.RecipeRepository).Assembly)
                   .AsImplementedInterfaces()
                   .SingleInstance();

            //Uncomment for SQL storage
//            builder.RegisterType<DataContext>().AsSelf().InstancePerRequest();
//            builder.RegisterAssemblyTypes(typeof(Data.SQL.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().InstancePerRequest();           

            //Uncomment for Azure table storage
//            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Table.Repositories.RecipeRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            //Uncomment for Azure DocumentDb storage
//            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.DocumentDb.RecipeRepository).Assembly).AsImplementedInterfaces().InstancePerRequest().PropertiesAutowired();

            //Uncomment for storage queue
            //builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Queue.Repositories.BookCreationRequestRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            //Uncomment for PostgreSQL storage
//            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.Postgres.IPostgresRepository).Assembly).AsImplementedInterfaces().InstancePerRequest().PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(PancakeProwler.Data.ServiceBus.Repositories.BookCreationRequestRepository).Assembly).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterType<PancakeProwler.Data.Common.Repositories.BlobImageRepository>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(x => x.Name.EndsWith("Controller")).AsSelf().PropertiesAutowired();
            return builder.Build();
        }
    }
}