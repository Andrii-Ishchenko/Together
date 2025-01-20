using System.Runtime.CompilerServices;
using System.Security.Claims;
using Domain.Models;
using Infrastructure;
using Infrastructure.Database;

namespace WebApi.Endpoints;

public static class RouteEndpoint
{
    public static IEndpointRouteBuilder MapRouteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/route/{id}", GetRoute)
            .WithName("GetRoute");

        endpoints.MapGet("/route/secured", SecuredGet)
            .WithName("GetSecuredRoute")
            .RequireAuthorization();

        return endpoints;
    }

    private static async Task<IResult> SecuredGet(ClaimsPrincipal user)
    {
        return await Task.FromResult(Results.Ok($"Hello {user.Identity?.Name}. My secret"));
    }

    private static async Task<IResult> GetRoute(int id, TogetherDbContext togetherDbContext)
    {
        var can = togetherDbContext.Database.CanConnect();

        return await Task.FromResult(Results.Ok($"{can}"));
    }
}
