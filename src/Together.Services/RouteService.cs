using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Together.DataAccess;
using Together.Domain.Entities;
using Together.Services.Requests;

namespace Together.Services
{
    public class RouteService : IRouteService
    {
        private readonly TogetherDbContext _dbContext;

        public RouteService(TogetherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Passenger> AddPassenger(CreatePassengerRequest model)
        {
            if (string.IsNullOrEmpty(model.UserId) || model.RouteId < 0)
            {
                throw new ArgumentException("Invalid passenger model");
            }

            using (_dbContext)
            {
                //TODO: refactor as separate method
                var existingUser = await _dbContext.UserProfiles
                        .FirstOrDefaultAsync(p => p.Id == model.UserId);

                if (existingUser == null)
                {
                    throw new Exception("User does not exist");
                }

                //TODO: refactor as separate method
                var existingRoute = _dbContext.Routes
                    .Include(r => r.Passengers)
                        .ThenInclude(p => p.User)
                    .FirstOrDefault(r => r.Id == model.RouteId);
                if (existingRoute == null)
                {
                    throw new Exception("Route does not exist");
                }

                var existingPassenger = existingRoute.Passengers.FirstOrDefault(p => p.UserId == model.UserId);
                if (existingPassenger != null)
                {
                    throw new Exception("Passenger already exists");
                }

                if(existingRoute.Passengers.Count == existingRoute.MaxPassengers)
                {
                    throw new Exception("Route is full");
                }

                var passenger = new Passenger()
                {
                    JoinDate = DateTime.UtcNow,
                    Route = existingRoute,
                    User = existingUser
                };

                existingRoute.Passengers.Add(passenger);

                //_dbContext.Passengers.Add(passenger);
                await _dbContext.SaveChangesAsync();

                return passenger;
            }
        }

        public async Task<Route> GetRoute(int routeId)
        {
            if(routeId < 0)
            {
                return null;
            }

            using (_dbContext)
            {
                var route = await _dbContext.Routes
                    .Include(r => r.Creator)
                    .Include(r => r.RoutePoints)
                    .Include(r => r.Passengers)
                    .FirstOrDefaultAsync(r => r.Id == routeId);

                if(route == null)
                {
                    return null;
                }

                route.RoutePoints = route.RoutePoints.OrderBy(rp => rp.OrderNumber).ToList();

                return route;
            }
        }

        public async Task<List<Route>> List()
        {
            using (_dbContext)
            {
                return  await _dbContext.Routes
                    .Include(r => r.Creator)
                    .Include(r => r.Passengers)
                    .Include(r => r.RoutePoints)
                    .ToListAsync();

            }
        }
    }
}
