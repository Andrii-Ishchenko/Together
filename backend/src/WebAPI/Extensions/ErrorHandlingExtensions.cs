namespace WebApi.Extensions;

static class ErrorHandlingExtensions
{
    public static void AddGlobalErrorHandling(this WebApplication app)
    {
        AddFallbackError(app);
        AddErrorLogging(app);
    }

    private static void AddFallbackError(WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                await Results.Json("An internal error occurred", statusCode: 500).ExecuteAsync(context);
            }
        });
    }

    private static void AddErrorLogging(WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, "Unhandled exception. Type: {ExceptionType}, Message: {Message}", ex.GetType().ToString(), ex.Message);
                throw;
            }
        });
    }
}
