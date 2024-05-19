using Together.WebAPI.Endpoints;

namespace Together.WebAPI.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this WebApplication endpoints)
    {
        endpoints.MapRouteEndpoints();

        return endpoints;
    }
}
