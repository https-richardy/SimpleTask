namespace HttpsRichardy.SimpleTask.WebApi.Middlewares;

public static class CorsMiddlewareConfiguration
{
    public static void UseCorsConfiguration(this IApplicationBuilder app)
    {
        app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    }
}
