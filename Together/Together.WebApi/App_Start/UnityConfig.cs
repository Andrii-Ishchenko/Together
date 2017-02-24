using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Together.BL.Services.Abstract;
using Together.BL.Services.Concrete;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;
using Together.DAL.Repository.Concrete;
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


            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType<IPointRepository, PointRepository>();
            container.RegisterType<IRouteRepository, RouteRepository>();
            container.RegisterType<IRoutePointRepository, RoutePointRepository>();
            
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType<IPointService, PointService>();
            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<IRoutePointService, RoutePointService>();

            container.RegisterType<DbContext, TogetherDbContext>(new PerThreadLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}