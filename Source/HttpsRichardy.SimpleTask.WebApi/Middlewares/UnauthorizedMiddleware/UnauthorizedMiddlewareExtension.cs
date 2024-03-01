namespace HttpsRichardy.SimpleTask.WebApi.Middlewares;

public static class UnauthorizedExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseUnauthorizedExceptionMiddlewareHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UnauthorizedExceptionMiddleware>();
    }
}