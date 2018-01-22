using Microsoft.Practices.Unity;
using System.Web.Http;
using Together.BL.Services;
using Together.DAL.Infrastructure;
using Together.DAL.Repository;

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


            container.RegisterType<IRouteRepository, RouteRepository>();
            container.RegisterType<IRoutePointRepository, RoutePointRepository>();

            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof (IBaseRepository<>), typeof (BaseRepository<>));

            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<IRoutePointService, RoutePointService>();
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}