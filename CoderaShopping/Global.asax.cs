using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CoderaShopping.Business;
using CoderaShopping.Business.Services;
using CoderaShopping.DataNHibernate;
using NHibernate;

namespace CoderaShopping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationConfig.Configure();

            // autofac
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest().PropertiesAutowired();
            builder.RegisterInstance(FhConfig.CreateSessionFactory()).As<ISessionFactory>();

            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly)
                .Where(x => x.Namespace.EndsWith(".Services"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            // scans for repositories in the repositories assembly
            builder.RegisterAssemblyTypes(typeof(IRepository<Object>).Assembly)
                .Where(x => x.Namespace.EndsWith(".Repositories"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
