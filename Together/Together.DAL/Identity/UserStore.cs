using Microsoft.AspNet.Identity.EntityFramework;
using Together.DAL.Infrastructure;
using Together.Domain.Identity;

namespace Together.DAL.Identity
{
    public class UserStore : UserStore<User>
    {
        public UserStore(TogetherDbContext context) : base(context)
        {
        }
    }
}
