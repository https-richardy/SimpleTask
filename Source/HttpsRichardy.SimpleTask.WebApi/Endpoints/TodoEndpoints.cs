using HttpsRichardy.SimpleTask.Application.Commands;
using MediatR;

public static class TodoEndpoints
{
    public static void ConfigureTodoEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("api/todos", async (IMediator mediator, CreateTodoCommand request) =>
        {
            await mediator.Send(request);
            return Results.Created();
        });
    }
}