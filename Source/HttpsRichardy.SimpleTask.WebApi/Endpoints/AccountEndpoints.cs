using HttpsRichardy.SimpleTask.Application.AccountContext.Commands;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries;
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

        endpoint.MapPost("api/accounts/authenticate", async (IMediator mediator, AuthenticationQuery request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        });
    }
}