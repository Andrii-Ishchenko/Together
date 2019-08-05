using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Unity;
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

            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<IRoutePointService, RoutePointService>();
            container.RegisterType<IPassengerService, PassengerService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IDbContextFactory<TogetherDbContext>, TogetherDbContextFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}