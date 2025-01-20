using Microsoft.Extensions.FileProviders;

namespace WebApi.Extensions;

internal static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureApplication(
    this IConfigurationBuilder builder,
    IHostEnvironment environment)
    {
        //var configFileProvider = new PhysicalFileProvider("/app/configs");
        //var vaultFileProvider = new PhysicalFileProvider("/vault/secrets");

        builder
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile(configFileProvider, "helloworld-settings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile(vaultFileProvider, "helloworld-secrets.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        return builder;
    }
}
