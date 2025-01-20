using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;
public class TogetherDbContext : IdentityDbContext<User, Role, int>
{
    public TogetherDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
