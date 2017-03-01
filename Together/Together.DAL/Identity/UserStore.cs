using Microsoft.AspNet.Identity.EntityFramework;
using Together.DAL.Entities;
using Together.DAL.Entities.Identity;
using Together.DAL.Infrastructure.Concrete;

namespace Together.DAL.Identity
{
    public class UserStore : UserStore<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(TogetherDbContext context) : base(context)
        {
        }
    }
}
