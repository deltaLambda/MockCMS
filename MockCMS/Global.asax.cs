using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Routing;
using MockCMS.Repositories;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace MockCMS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{id}/{path}",
                defaults: new { controller = "MockSite", action = "ViewSite", path = UrlParameter.Optional },
                constraints: new { id = @"([^_]).*" }
            );
            routes.MapRoute(
                name: "SitesIndex",
                url: "_{action}/{id}",
                defaults: new { controller = "MockSite", action = "Index", id = UrlParameter.Optional }
            );
        }
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IMockSiteRepository>().To<FakeMockSiteRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            return kernel;
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }
    public class NinjectResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectResolver(IKernel kernel)
        : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}