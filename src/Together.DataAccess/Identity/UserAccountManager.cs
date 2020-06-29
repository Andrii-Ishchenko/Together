using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Together.Domain.Entities;

namespace Together.DataAccess.Identity
{

    public class UserAccountManager : UserManager<UserAccount>
    {
        public UserAccountManager(IUserStore<UserAccount> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<UserAccount> passwordHasher,
            IEnumerable<IUserValidator<UserAccount>> userValidators,
            IEnumerable<IPasswordValidator<UserAccount>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services, ILogger<UserManager<UserAccount>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }

}
