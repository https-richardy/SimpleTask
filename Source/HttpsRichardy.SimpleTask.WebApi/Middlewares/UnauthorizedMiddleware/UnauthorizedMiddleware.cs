using HttpsRichardy.SimpleTask.Domain.Exceptions;

namespace HttpsRichardy.SimpleTask.WebApi.Middlewares;

public class UnauthorizedExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedException ex)
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(ex.Message);
        }
    }
}