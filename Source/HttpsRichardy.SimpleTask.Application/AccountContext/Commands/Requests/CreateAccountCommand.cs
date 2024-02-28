using MediatR;
using HttpsRichardy.SimpleTask.Application.AccountContext.Commands.Responses;

namespace HttpsRichardy.SimpleTask.Application.AccountContext.Commands;

public record CreateAccountCommand : IRequest<CreateAccountResponse>
{
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}