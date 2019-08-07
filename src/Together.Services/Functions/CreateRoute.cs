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

        public NewRouteModel Create(CreateRouteRequest request)
        {
            if (!_userService.UserExists(request.CreatorId))
            {
                throw new UserNotFoundException(request.CreatorId);
            }

            var route = new Route()
            {
                CreatorId = request.CreatorId,
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

            _passengerService.AddUserToRoute(request.CreatorId, route.Id);

            return AutoMapper.Mapper.Map<NewRouteModel>(route);
        }
    }
}
