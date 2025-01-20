namespace WebApi.Extensions;

internal static class WebApplicationExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the request pipeline for your application here
        app.UseApplicationMiddleware(app.Environment);
        app.MapApplicationEndpoints();
        app.AddGlobalErrorHandling();

        return app;
    }
}
