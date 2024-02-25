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

        endpoint.MapPost("api/todos", async (IMediator mediator, CreateTodoCommand request) =>
        {
            await mediator.Send(request);
            return Results.Created();
        });
    }
}