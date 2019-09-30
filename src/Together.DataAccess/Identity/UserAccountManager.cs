using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;

namespace Together.DataAccess.Identity
{
    public class UserAccountManager : UserManager<UserAccount>
    {
        public UserAccountManager(IUserStore<UserAccount> store) : base(store)
        {
        }
    }
}
