using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Data.Domain;

namespace Together.Data.Context
{
    public class TogetherDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }


        public TogetherDbContext() : base("TogetherDBConnection")
        {

        }
    }
}
