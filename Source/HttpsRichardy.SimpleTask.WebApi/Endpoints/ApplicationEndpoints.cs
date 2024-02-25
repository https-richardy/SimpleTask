public static class ApplicationEndpoints
{
    public static void ConfigureEndpoints(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            TodoEndpoints.ConfigureTodoEndpoints(endpoints);
        });
    }
}