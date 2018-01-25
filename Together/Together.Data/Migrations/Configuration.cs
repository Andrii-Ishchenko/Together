namespace Together.Data.Migrations
{
    using Context;
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TogetherDbContext>
    {
        public Configuration()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TogetherDbContext>());
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TogetherDbContext context)
        {
            var rp = new RoutePoint()
            {
                Address = "Some Address",
                Latitude = 123.0,
                Longitude = 234.0
            };

            var route = new Route()
            {
                CreateDate = DateTime.Now,
                RouteType = "MyType"
            };

            route.RoutePoints.Add(rp);

            context.Routes.Add(route);
            context.SaveChanges();
        }
    }
}
