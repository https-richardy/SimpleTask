using HttpsRichardy.SimpleTask.Infra.IoC;
using HttpsRichardy.SimpleTask.WebApi.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureServices(configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseValidationExceptionHandler();
        app.UseObjectDoesNotExistExceptionHandler();

        app.ConfigureEndpoints();
        app.UseHttpsRedirection();

        app.Run();
    }
}