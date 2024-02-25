using HttpsRichardy.SimpleTask.Domain.Exceptions;

namespace HttpsRichardy.SimpleTask.WebApi.Middlewares;

public class ObjectDoesNotExistExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ObjectDoesNotExistExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ObjectDoesNotExistException ex)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(ex.Message);
        }
    }
}