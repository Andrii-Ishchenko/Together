using Microsoft.Practices.Unity;
using System.Web.Http;
using Together.Data.Context;
using Together.Services.Route;
using Unity.WebApi;

namespace Together.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType(typeof (IRouteCRUDService), typeof (RouteCRUDService));

            container.RegisterInstance(typeof (TogetherDbContext), new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}