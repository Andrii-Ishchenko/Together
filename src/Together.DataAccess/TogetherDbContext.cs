using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Together.Domain.Entities;

namespace Together.DataAccess
{
    public class TogetherDbContext : IdentityDbContext<UserAccount, UserRole, string>
    {
        public TogetherDbContext(DbContextOptions<TogetherDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.Id);

            //TODO: THINK ABOUT CASCADE ACTIONS ON DELETE OF MASTER ENTITY

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.Route).WithMany(r => r.Passengers)
                .HasForeignKey(p => p.RouteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.User).WithMany(u => u.Passengers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserProfile>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserProfile>()
                 .HasOne(u => u.UserAccount)
                 .WithOne(u => u.UserProfile)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Route>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.Creator).WithMany(u => u.CreatedRoutes)
                .HasForeignKey(r => r.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoutePoint>()
                .HasKey(rp => rp.Id);

            modelBuilder.Entity<RoutePoint>()
                .HasOne(rp => rp.Route).WithMany(r => r.RoutePoints)
                .HasForeignKey(rp => rp.RouteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoutePoint>()
                .HasOne(rp => rp.Creator).WithMany(u => u.CreatedRoutePoints)
                .HasForeignKey(rp => rp.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
