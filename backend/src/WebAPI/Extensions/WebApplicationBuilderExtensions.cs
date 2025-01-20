namespace WebApi.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplication(this WebApplicationBuilder builder)
    {
        builder.Logging.ConfigureApplication(builder.Configuration);
        builder.Configuration.ConfigureApplication(builder.Environment);
        builder.Services.AddApplicationServices(builder);
        builder.WebHost.ConfigureApplication();

        return builder;
    }
}
