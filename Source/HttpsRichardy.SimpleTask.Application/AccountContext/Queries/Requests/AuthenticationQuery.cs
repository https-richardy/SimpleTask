using MediatR;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries.Responses;

namespace HttpsRichardy.SimpleTask.Application.AccountContext.Queries;

public record AuthenticationQuery : IRequest<AuthenticationQueryResponse>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}