using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;
using Together.DataAccess.Identity;
using Together.Domain.Entities;

namespace Together.Services.Functions
{
    public class Authentication
    {
        private TogetherDbContext _context;
        private UserAccountManager _userAccountManager;

        public Authentication(TogetherDbContextFactory factory)
        {
            _context = factory.Create();
            _userAccountManager = new UserAccountManager(new UserStore<UserAccount>(_context));
        }

        public async Task<bool> UserExist(string email, string password)
        {
            return FindUser(email, password) != null;     
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userAccountManager.FindAsync(userName, password);

            return user;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(UserAccount user, string defaultAuthenticationType)
        {
            return await _userAccountManager.CreateIdentityAsync(user, defaultAuthenticationType);
        }
    }
}
