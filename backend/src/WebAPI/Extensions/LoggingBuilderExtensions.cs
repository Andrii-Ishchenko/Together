using Serilog;

namespace WebApi.Extensions;

internal static class LoggingBuilderExtensions
{
    public static ILoggingBuilder ConfigureApplication(
        this ILoggingBuilder builder,
        IConfiguration configuration)
    {
        builder.ClearProviders();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        return builder.AddSerilog();
    }
}