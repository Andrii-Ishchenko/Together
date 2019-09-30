using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            using (_context)
            {
                // username == email
                var userAccount = await _userAccountManager.FindAsync(email, password);
                return userAccount != null;
            }         
        }
    }
}
