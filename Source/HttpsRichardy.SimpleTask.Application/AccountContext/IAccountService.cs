using HttpsRichardy.SimpleTask.Application.AccountContext.Commands;
using HttpsRichardy.SimpleTask.Application.AccountContext.Commands.Responses;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries.Responses;

namespace HttpsRichardy.SimpleTask.Application.Contracts.Services;

public interface IAccountService
{
    Task<CreateAccountResponse> CreateUserAsync(CreateAccountCommand request);
    Task<AuthenticationQueryResponse> AuthenticateAsync(AuthenticationQuery request);
}