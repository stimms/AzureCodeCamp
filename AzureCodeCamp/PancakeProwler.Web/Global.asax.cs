using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Web.Optimization;

namespace PancakeProwler.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private NLog.Logger _log;
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateLogger();
            CreateContainer();
            InitDataLayer();
            
        }

        private void CreateLogger()
        {
            _log = NLog.LogManager.GetLogger("PancakeProwler");
        }

        private void CreateContainer()
        {
            var builder = new ContainerBuilder();
            var container = builder.BuildContainer(_log);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void InitDataLayer()
        {
            //NOTE: Use DependencyResolver.Current here instead of accessing the container directly
            DependencyResolver.Current.GetService<Data.Common.IDataLayerConfigurator>().Configure();
        }
    }
}