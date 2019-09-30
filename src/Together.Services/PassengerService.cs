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

namespace Together.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IRouteService _routeService;
        private readonly IUserService _userService;
        private readonly TogetherDbContextFactory _dbContextFactory;

        public PassengerService(IRouteService routeService, IUserService userService, TogetherDbContextFactory dbContextFactory)
        {
            _routeService = routeService;
            _userService = userService;
            _dbContextFactory = dbContextFactory;
        }

        public NewPassengerModel AddUserToRoute(string userId, int routeId)
        {
            if (!_routeService.RouteExists(routeId))
            {
                throw new RouteNotFoundException(routeId);
            }

            if (!_userService.UserExists(userId))
            {
                throw new UserNotFoundException(userId);
            }
                     
            using (var db = _dbContextFactory.Create())
            {
                //TODO: refactor to separate method
                if (db.Passengers.Any(p => p.RouteId == routeId && p.UserId == userId))
                {
                    throw new PassengerAlreadyExistsException(userId, routeId);
                }

                var route = db.Routes.Find(routeId);

                if(route.MaxPassengers == route.Passengers.Count)
                {
                    throw new RouteFullException();
                }

                Passenger passenger = new Passenger() { UserId = userId, RouteId = routeId, JoinDate = DateTime.UtcNow };
                db.Passengers.Add(passenger);
                db.SaveChanges();

                return AutoMapper.Mapper.Map<Passenger, NewPassengerModel>(passenger);
            }
        }


        public void DeletePassenger(int passengerId)
        {        
            using (var db = _dbContextFactory.Create())
            {
                var passenger = db.Passengers.FirstOrDefault(p => p.Id == passengerId);

                if (passenger != null)
                {
                    db.Passengers.Remove(passenger);
                    db.SaveChanges();
                }
            }
        }
    }
}
