using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Together.DAL.Infrastructure;
using Together.Domain;
using Together.Domain.Identity;

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


            var manager = new UserManager<User>(new UserStore<User>(context));

            var user1 = new User()
            {
                UserName = "admin4",
                Email = "admin@google.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false
            };

            var appUser1 = new AppUser()
            {
                FirstName = "Taksist4",
                LastName = "Lanos"
            };

            user1.AppUser = appUser1;

            manager.Create(user1, "qwerty");
            context.SaveChanges();

        }
    }
}
