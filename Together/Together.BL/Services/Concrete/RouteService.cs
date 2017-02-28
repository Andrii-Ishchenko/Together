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
        public RouteService(IUnitOfWorkFactory factory): base(factory)
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
                IsPrivate = model.IsPrivate,
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

            route.IsPrivate = model.IsPrivate;        
             
            TryDecreaseMaxPassengers(route,model);

            route.RouteType = model.RouteType;
            //TODO: if route type changed,check max route points

            //TODO: if route is private then secret key should be set.
            route.SecretKey = model.SecretKey;

            if (model.StartDate <= DateTime.Now)
            {
                throw new Exception("You cannot set route start time preceeding current time.");
            }
            else
            {
                route.StartDate = model.StartDate;
            }

            Update(route);

            return route;
        }

        private void TryDecreaseMaxPassengers(Route route, UpdateRouteModel model)
        {
            if (model.MaxPassengers <= route.MaxPassengers)
                throw new NotImplementedException();

            route.MaxPassengers = model.MaxPassengers;

        }
    }
}
