using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Together.Domain.Models;

namespace Together.Persistence;
public  class TogetherDbContext : IdentityDbContext<User,Role, int>
{

    public TogetherDbContext(DbContextOptions<TogetherDbContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }
}
