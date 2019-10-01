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
using System.Data.Entity.Infrastructure;
using Together.Services.Interfaces;

namespace Together.Services
{
    public class RoutePointService : IRoutePointService
    {
        private readonly TogetherDbContextFactory _dbContextFactory;
        private readonly IRouteService _routeService;
        private readonly IUserService _userService;

        public RoutePointService(IDbContextFactory<TogetherDbContext> dbContextFactory, IRouteService routeService, IUserService userService)
        {
            _dbContextFactory = dbContextFactory as TogetherDbContextFactory;
            _routeService = routeService;
            _userService = userService;
        }

        public NewRoutePointModel AddPointToRoute(string userId, CreateRoutePointRequest request)
        {
            if (!_userService.UserExists(userId))
            {
                throw new UserNotFoundException(userId);
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
                    CreatorId = userId,
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
