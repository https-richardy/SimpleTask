using HttpsRichardy.SimpleTask.Application.AccountContext.Commands;
using MediatR;

public static class AccountEndpoints
{
    public static void ConfigureAccountEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("api/accounts/register", async (IMediator mediator, CreateAccountCommand request) =>
        {
            await mediator.Send(request);
            return Results.Created();
        });
    }
}