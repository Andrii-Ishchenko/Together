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
    }
}
