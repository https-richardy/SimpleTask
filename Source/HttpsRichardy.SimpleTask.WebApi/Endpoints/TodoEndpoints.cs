using HttpsRichardy.SimpleTask.Application.Commands;
using HttpsRichardy.SimpleTask.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class TodoEndpoints
{
    public static void ConfigureTodoEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("api/todos", async (IMediator mediator, [FromQuery] string? title = null, [FromQuery] bool IsCompleted = false) =>
        {
            # pragma warning disable CS8601
            var request = new RetrieveAllTodosQuery
            {
                Title = title, /* CS8601: Possible null reference assignment. */
                IsCompleted = IsCompleted
            };

            var response = await mediator.Send(request);
            return Results.Ok(response);
        });

        endpoint.MapGet("api/todos/{id}", async (IMediator mediator, [FromRoute] int id) =>
        {
            var request = new RetrieveTodoByIdQuery { Id = id };

            var response = await mediator.Send(request);
            return response != null ? Results.Ok(response) : Results.NotFound();
        });

        endpoint.MapPost("api/todos", async (IMediator mediator, CreateTodoCommand request) =>
        {
            await mediator.Send(request);
            return Results.Created();
        });

        endpoint.MapPost("api/todos/complete/{id}", async (IMediator mediator, [FromRoute] int id) =>
        {
            var request = new CompleteTodoCommand { TodoId = id };
            await mediator.Send(request);
        });

        endpoint.MapPut("api/todos/", async (IMediator mediator, UpdateTodoCommand request) =>
        {
            await mediator.Send(request);

            return Results.NoContent();
        });
    }
}