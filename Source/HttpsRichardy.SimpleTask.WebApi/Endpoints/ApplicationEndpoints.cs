public static class ApplicationEndpoints
{
    public static void ConfigureEndpoints(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            TodoEndpoints.ConfigureTodoEndpoints(endpoints);
            AccountEndpoints.ConfigureAccountEndpoints(endpoints);
        });
    }
}