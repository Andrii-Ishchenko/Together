using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Together.Domain.Models;
using Together.Persistence;
namespace Together.WebAPI.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<TogetherDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("TogetherDb");
            options.UseSqlServer(connectionString, opt => {
                opt.MigrationsAssembly("Together.Persistence");
            });
        });

        services.AddAuthorization();

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<TogetherDbContext>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}

