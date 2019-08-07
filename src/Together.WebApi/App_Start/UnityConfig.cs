using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Together.Services.Functions;
using Together.Services.Interfaces;
using Unity;
using Unity.Lifetime;
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

            container.RegisterType<ICreateRoute, CreateRoute>();

            container.RegisterType<IDbContextFactory<TogetherDbContext>, TogetherDbContextFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}