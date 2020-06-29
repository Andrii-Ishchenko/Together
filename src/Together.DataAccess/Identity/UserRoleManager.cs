using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Together.Domain.Entities;

namespace Together.DataAccess.Identity
{

    public class UserRoleManager : RoleManager<UserRole>
    {
        public UserRoleManager(IRoleStore<UserRole> store,
            IEnumerable<IRoleValidator<UserRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<UserRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }

}
