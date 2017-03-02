using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Together.DAL.Infrastructure;
using Together.Domain;

namespace Together.DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<TogetherDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;		
        }

        protected override void Seed(TogetherDbContext context)
        {
			//context.Points.AddOrUpdate(new Point { Latitude = 1, Longitude = 11 });
   //         context.Points.AddOrUpdate(new Point { Latitude = 2, Longitude = 12 });
   //         context.Points.AddOrUpdate(new Point { Latitude = 3, Longitude = 13 });
   //         context.Points.AddOrUpdate(new Point { Latitude = 4, Longitude = 14 });
   //         context.Points.AddOrUpdate(new Point { Latitude = 5, Longitude = 15 });

   //         AppUser u1 = new AppUser() {FirstName = "John", LastName = "Doe"};
   //         AppUser u2 = new AppUser() {FirstName = "Jane", LastName = "Doe"};
   //         AppUser u3 = new AppUser() {FirstName = "Agent", LastName = "Smith"};
   //         context.AppUsers.Add(u1);
   //         context.AppUsers.Add(u2);
   //         context.AppUsers.Add(u3);

   //         context.SaveChanges();

   //         Route r = new Route()
   //         {
   //             CreateDate = DateTime.Now,
   //             IsPrivate = false,
   //             MaxPassengers = 5,
   //             Owner = u1,
   //             RouteType = "Standard",
   //             StartDate = DateTime.Now.AddDays(7)
   //         };
   //         context.Routes.Add(r);

   //         context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
