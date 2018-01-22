using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain;
using Together.Domain.Identity;

namespace Together.DAL.Infrastructure
{
    public class TogetherDbContext : IdentityDbContext<User>
    {
        static int count = 0;

        public TogetherDbContext()
            :base("TogetherDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TogetherDbContext>());

            Database.Log = s => Debug.WriteLine(s);

            Debug.WriteLine("TOGETHER DB CONTEXT CREATED({0})",count++);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AppUser>()
                .HasRequired(u => u.User)
                .WithRequiredDependent(x => x.AppUser);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<RouteUser> RouteUsers { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
       

    }
}
