using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;
using Together.Domain.Entities;
using Together.Services.Exceptions;
using Together.Services.Interfaces;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Functions
{
    public class CreateRoute : ICreateRoute
    {
        private readonly TogetherDbContextFactory _factory;
        private readonly IUserService _userService;
        private readonly IPassengerService _passengerService;

        public CreateRoute(TogetherDbContextFactory factory, IUserService userService, IPassengerService passengerService)
        {
            _factory = factory;
            _userService = userService;
            _passengerService = passengerService;
        }

        public NewRouteModel Create(string userId, CreateRouteRequest request)
        {
            if (!_userService.UserExists(userId))
            {
                throw new UserNotFoundException(userId);
            }

            var route = new Route()
            {
                CreatorId = userId,
                CreateDate = DateTime.UtcNow,
                IsPrivate = request.IsPrivate,
                MaxPassengers = request.MaxPassengers,
                RouteType = request.RouteType,
                StartDate = request.StartDate,
                Name = request.Name
            };

            using (var db = _factory.Create())
            {
                db.Routes.Add(route);
                db.SaveChanges();
            }

            // TODO: maybe put inside using to leverage single context after setting correct context lifecycle
            _passengerService.AddUserToRoute(userId, route.Id);

            return AutoMapper.Mapper.Map<NewRouteModel>(route);
        }
    }
}
