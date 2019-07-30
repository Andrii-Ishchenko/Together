using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;

namespace Together.Services
{
    public class UserService : IUserService
    {
        private readonly TogetherDbContextFactory _dbContextFactory;

        public UserService(TogetherDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool UserExists(int userId)
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                return db.Users.Any(u => u.Id == userId);
            }
        }
    }
}
