using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Entities;
using Together.DAL.Entities.Identity;
using Together.DAL.Infrastructure.Concrete;

namespace Together.DAL.Identity
{
    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(TogetherDbContext context) : base(context)
        {
        }
    }
}
