using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Together.DataAccess;
using Together.Services.Exceptions;
using Together.Services.Models;
using Together.Services.Requests;
using Together.Domain.Entities;

namespace Together.Services
{
    public class RoutePointService : IRoutePointService
    {
        private readonly TogetherDbContextFactory _dbContextFactory;
        private readonly RouteService _routeService;
        private readonly UserService _userService;

        public RoutePointService(TogetherDbContextFactory dbContextFactory, RouteService routeService, UserService userService)
        {
            _dbContextFactory = dbContextFactory;
            _routeService = routeService;
            _userService = userService;
        }

        public NewRoutePointModel AddPointToRoute(CreateRoutePointRequest request)
        {
            if (!_userService.UserExists(request.UserId))
            {
                throw new UserNotFoundException(request.UserId);
            }

            if(!_routeService.RouteExists(request.RouteId))
            {
                throw new RouteNotFoundException(request.RouteId);
            }

            using(var db = _dbContextFactory.Create())
            {
                RoutePoint rp = new RoutePoint()
                {
                    RouteId = request.RouteId,
                    CreatorId = request.UserId,
                    CreatedDate = DateTime.UtcNow,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    OrderNumber = request.OrderNumber,
                    Name = request.Name
                };

                db.RoutePoints.Add(rp);
                db.SaveChanges();

                return AutoMapper.Mapper.Map<RoutePoint, NewRoutePointModel>(rp);
                
            }
        }
    }
}
