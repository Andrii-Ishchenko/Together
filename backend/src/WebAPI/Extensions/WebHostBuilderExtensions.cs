namespace WebApi.Extensions;

internal static class WebHostBuilderExtensions
{
    public static IWebHostBuilder ConfigureApplication(this IWebHostBuilder builder)
    {
        builder.CaptureStartupErrors(true);

        builder.ConfigureKestrel((p) =>
        {
            p.AddServerHeader = false;
        });

        return builder;
    }
}