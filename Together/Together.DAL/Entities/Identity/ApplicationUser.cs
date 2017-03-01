using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Entities.Identity;

namespace Together.DAL.Entities
{
    public class ApplicationUser : IdentityUser<int,UserLogin,UserRole,UserClaim>
    {
        public virtual User User { get; set; }
    }
}
