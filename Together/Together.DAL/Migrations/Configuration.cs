using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Together.DAL.Infrastructure.Concrete;
using Together.Domain.Entities;

namespace Together.DAL.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<Together.DAL.Infrastructure.Concrete.TogetherDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;		
        }

        protected override void Seed(TogetherDbContext context)
        {
			context.Points.AddOrUpdate(new Point { Latitude = 123, Longitude = 456 });

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
