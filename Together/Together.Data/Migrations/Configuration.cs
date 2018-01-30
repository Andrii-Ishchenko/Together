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
            Database.SetInitializer(new DropCreateDatabaseAlways<TogetherDbContext>());
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TogetherDbContext context)
        {

            for (var r = 0; r < 4; r++)
            {
                var route = new Route()
                {
                    CreateDate = DateTime.Now.AddHours(r),
                    RouteType = "MyType"
                };

                for (int i = 0; i < 5 + r; i++)
                {
                    var rp = new RoutePoint()
                    {
                        Address = "Some Address",
                        Latitude = 123.0 + i,
                        Longitude = 234.0 + i
                    };

                    route.RoutePoints.Add(rp);
                }

                context.Routes.Add(route);
            }

            context.SaveChanges();
        }
    }
}
