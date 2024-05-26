using System.Runtime.CompilerServices;
using Together.Persistence;

namespace Together.WebAPI.Endpoints;

public static class RouteEndpoint
{
    public static IEndpointRouteBuilder MapRouteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/route/{id}", GetRoute)
            .WithName("GetRoute");

        return endpoints;
    }

    private static async Task<IResult> GetRoute(int id, TogetherDbContext togetherDbContext)
    {
        var can = togetherDbContext.Database.CanConnect();

        return await Task.FromResult(Results.Ok($"{can}"));
    }
}
