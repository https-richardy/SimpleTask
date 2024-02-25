using HttpsRichardy.SimpleTask.Application.Commands;
using HttpsRichardy.SimpleTask.Infra.IoC;
using MediatR;

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

        app.MapPost("api/todos", async (IMediator mediator, CreateTodoCommand request) =>
        {
            var response = await mediator.Send(request);
            return Results.Created();
        });

        app.UseHttpsRedirection();


        app.Run();
    }
}