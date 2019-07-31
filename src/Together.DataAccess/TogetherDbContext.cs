using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;

namespace Together.DataAccess
{
    public class TogetherDbContext : DbContext
    {

        public TogetherDbContext()
            :base("name=TogetherDb")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<TogetherDbContext, Migrations.Configuration>());
            Database.SetInitializer(new TogetherDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Passenger>()
                .HasRequired(p => p.Route).WithMany(r => r.Passengers)
                .HasForeignKey(p => p.RouteId);

            modelBuilder.Entity<Passenger>()
                .HasRequired(p => p.User).WithMany(u => u.Passengers)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Route>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<RoutePoint>()
                .HasKey(rp => rp.Id);

            modelBuilder.Entity<RoutePoint>()
                .HasRequired(rp => rp.Route).WithMany(r => r.RoutePoints)
                .HasForeignKey(rp => rp.RouteId);

            modelBuilder.Entity<RoutePoint>()
                .HasRequired(rp => rp.Creator).WithMany(u => u.CreatedRoutePoints)
                .HasForeignKey(rp => rp.CreatorId);
        }

    }
}
