using System.Security.Claims;
using HttpsRichardy.SimpleTask.Application.TodoContext.Commands;
using HttpsRichardy.SimpleTask.Application.TodoContext.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public static class TodoEndpoints
{
    public static void ConfigureTodoEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("api/todos", [Authorize] async (IMediator mediator, ClaimsPrincipal user, [FromQuery] string? title = null, [FromQuery] bool IsCompleted = false) =>
        {
            # pragma warning disable CS8601
            var request = new RetrieveAllTodosQuery
            {
                Title = title, /* CS8601: Possible null reference assignment. */
                IsCompleted = IsCompleted,
                UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };

            var response = await mediator.Send(request);
            return Results.Ok(response);
        });

        endpoint.MapGet("api/todos/{id}", [Authorize] async (IMediator mediator, [FromRoute] int id, ClaimsPrincipal user) =>
        {
            var request = new RetrieveTodoByIdQuery { Id = id, UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value };

            var response = await mediator.Send(request);
            return response != null ? Results.Ok(response) : Results.NotFound();
        });

        endpoint.MapPost("api/todos", [Authorize] async (IMediator mediator, CreateTodoCommand request, ClaimsPrincipal user) =>
        {
            request.UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await mediator.Send(request);
            return Results.Created();
        });

        endpoint.MapPost("api/todos/complete/{id}", [Authorize] async (IMediator mediator, [FromRoute] int id, ClaimsPrincipal user) =>
        {
            var request = new CompleteTodoCommand { TodoId = id, UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value };
            await mediator.Send(request);
        });

        endpoint.MapPut("api/todos/{id}", [Authorize] async (IMediator mediator, UpdateTodoCommand request, [FromRoute] int id, ClaimsPrincipal user) =>
        {
            request.UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            request.TodoId = id;

            await mediator.Send(request);

            return Results.NoContent();
        });

        endpoint.MapDelete("api/todos/{id}", [Authorize] async (IMediator mediator, [FromRoute] int id, ClaimsPrincipal user) =>
        {
            var request = new DeleteTodoCommand { TodoId = id, UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value};

            await mediator.Send(request);
            return Results.NoContent();
        });
    }
}