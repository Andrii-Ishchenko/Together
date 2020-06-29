using Microsoft.AspNetCore.Identity;

namespace Together.Domain.Entities
{
    public class UserAccount : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
