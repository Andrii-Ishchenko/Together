using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOModels.Route;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class RouteService : BaseService<Route>, IRouteService
    {
        public RouteService(IRouteRepository repository): base(repository)
        {
                
        }

        public Route CreateRoute(CreateRouteModel model)
        {
            //TODO: check max allowed routes
            //TODO: add default values
            //TODO: convert route type to enum
            var route = new Route()
            {
                CreateDate = DateTime.Now,
                IsPrivate = model.IsPrivate.GetValueOrDefault(false),
                MaxPassengers = model.MaxPassengers,
                RouteType = model.RouteType,
                OwnerId = 1, //TODO: add id from session
                StartDate = (model.StartDate == DateTime.MinValue) ? DateTime.Now.AddHours(1) : model.StartDate,
                SecretKey = model.SecretKey
            };

            Add(route);

            return route;
        }

        public Route UpdateRoute(UpdateRouteModel model)
        {
            var route = GetById(model.Id);

            if (route == null)
                throw new Exception("Route does not exist.");

            route.IsPrivate = model.IsPrivate ?? route.IsPrivate;

            route.MaxPassengers = model.MaxPassengers ?? route.MaxPassengers;

            route.RouteType = model.RouteType ?? route.RouteType;
            
            route.SecretKey = model.SecretKey ?? route.SecretKey ;

            route.StartDate = model.StartDate ?? route.StartDate;

            Update(route);

            return route;
        }
    }
}
