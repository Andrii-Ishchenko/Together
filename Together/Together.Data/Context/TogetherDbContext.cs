using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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


        public TogetherDbContext() : base("TogetherDB2")
        {
            Debug.WriteLine("CONTEXT CREATED");
            Database.Log = s => Debug.WriteLine(s);
           
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Debug.WriteLine("CONTEXT DISPOSED!!!!!!!!");
        }
    }
}
