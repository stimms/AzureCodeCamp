using System;
using Autofac;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Collections.Generic;

namespace PancakeProwler.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private NLog.Logger _log;
        private IContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
            _container = builder.BuildContainer(_log);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        private void InitDataLayer()
        {
            //NOTE: This is crashing when I try to use InstancePerHttpRequest configuration for 
            //      repositories and db context.  Need to review with stimms
          //  _container.Resolve<PancakeProwler.Data.Common.IDataLayerConfigurator>().Configure();
        }
    }
}