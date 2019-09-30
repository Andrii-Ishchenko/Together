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
            GlobalConfiguration.Configuration.DependencyResolver = GetDependencyResolver();
        }

        public static void RegisterComponents(HttpConfiguration config)
        {
            config.DependencyResolver = GetDependencyResolver();
        }

        private static UnityDependencyResolver GetDependencyResolver()
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
            container.RegisterType<IRegister, Register>();

            container.RegisterType<IDbContextFactory<TogetherDbContext>, TogetherDbContextFactory>();

            return new UnityDependencyResolver(container);
        }
    }
}