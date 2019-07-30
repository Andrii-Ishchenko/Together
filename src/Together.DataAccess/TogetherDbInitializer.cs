using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;

namespace Together.DataAccess
{
    class TogetherDbInitializer : DropCreateDatabaseAlways<TogetherDbContext>
    {
        protected override void Seed(TogetherDbContext context)
        {
            Console.WriteLine("Message from DbInitializer Seed");

            List<User> users = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                users.Add(new User() { FirstName = "User" + i, LastName = "LastName" + i });
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            Route route1 = new Route()
            {
                MaxPassengers = 3,
                CreateDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow.AddDays(100),
                RouteType = "Car",
                IsPrivate = false
            };

            Route route2 = new Route()
            {
                MaxPassengers = 5,
                CreateDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow.AddDays(100),
                RouteType = "Foot",
                IsPrivate = false
            };

            context.Routes.Add(route1);
            context.Routes.Add(route2);
            context.SaveChanges();

            var passenger1 = new Passenger()
            {
                RouteId = route1.Id,
                UserId = users[0].Id,
                JoinDate = DateTime.UtcNow
            };

            var passenger2 = new Passenger()
            {
                RouteId = route2.Id,
                UserId = users[0].Id,
                JoinDate = DateTime.UtcNow
            };

            var passenger3 = new Passenger()
            {
                RouteId = route1.Id,
                UserId = users[1].Id,
                JoinDate = DateTime.UtcNow
            };


            var passenger4 = new Passenger()
            {
                RouteId = route2.Id,
                UserId = users[2].Id,
                JoinDate = DateTime.UtcNow
            };

            context.Passengers.AddRange(new[] { passenger1, passenger2, passenger3, passenger4 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
