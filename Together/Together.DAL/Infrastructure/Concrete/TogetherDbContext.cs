using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;

namespace Together.DAL.Infrastructure.Concrete
{
    public class TogetherDbContext : DbContext
    {
        public TogetherDbContext()
            :base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<RouteUser> RouteUsers { get; set; }
        public DbSet<RoutePoint> RoutePoint { get; set; }

    }
}
