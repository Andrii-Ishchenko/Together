using Domain.Models;
using WebApi.Endpoints;

namespace WebApi.Extensions;

internal static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this WebApplication endpoints)
    {
        endpoints.MapRouteEndpoints();
        endpoints.MapIdentityApi<User>();

        return endpoints;
    }
}
