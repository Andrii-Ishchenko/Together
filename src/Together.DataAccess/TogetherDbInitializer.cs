using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess.Identity;
using Together.Domain.Entities;

namespace Together.DataAccess
{
    public class TogetherDBInitializer
    {
        private readonly TogetherDbContext _context;
        private readonly UserAccountManager _userAccountManager;
        private readonly UserRoleManager _userRoleManager;

        public TogetherDBInitializer(TogetherDbContext context, UserAccountManager userAccountManager, UserRoleManager userRoleManager)
        {
            _context = context;
            _userAccountManager = userAccountManager;
            _userRoleManager = userRoleManager;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole() { Name = "User" });
            userRoles.Add(new UserRole() { Name = "Admin" });
            userRoles.Add(new UserRole() { Name = "TestRole" });

            if (!_context.Roles.Any())
            {
                for (int i = 0; i < 3; i++)
                {
                    _ = _userRoleManager.CreateAsync(userRoles[i]).Result;
                }
            }

            if (!_context.Users.Any())
            {
                List<UserAccount> userAccounts = new List<UserAccount>();

                for (int i = 0; i < 3; i++)
                {
                    string email = $"user{i}_{userRoles[i].Name}@google.com";
                    string password = $"Password123$";
                    var userAccount = new UserAccount() { Email = email, UserName = email };
                    userAccounts.Add(userAccount);

                    var identityResult1 = await _userAccountManager.CreateAsync(userAccount, password);
                    var identityResult2 = await _userAccountManager.AddToRoleAsync(userAccount,userRoles[i].Name);
                }

                List<UserProfile> users = new List<UserProfile>();
                for (int i = 0; i < 3; i++)
                {
                    users.Add(new UserProfile() { Id = userAccounts[i].Id, FirstName = "User" + i, LastName = "LastName" + i });
                }

                _context.UserProfiles.AddRange(users);
                _context.SaveChanges();
            }
        }
    }
}
