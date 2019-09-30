﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;

namespace Together.DataAccess.Identity
{
    public class UserRoleManager : RoleManager<UserRole>
    {
        public UserRoleManager(IRoleStore<UserRole, string> store) : base(store)
        {
        }
    }
}