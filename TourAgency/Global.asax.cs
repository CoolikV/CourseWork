using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TourAgency.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using BLL.Infrastructure;
using TourAgency.App_Start;

namespace TourAgency
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.InitializeConfig();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule modules = new AppModule();
            NinjectModule serviceModule = new ServiceModule("AgencyDatabase");

            var kernel = new StandardKernel(modules, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
