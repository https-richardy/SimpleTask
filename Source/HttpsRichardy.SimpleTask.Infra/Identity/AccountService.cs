using HttpsRichardy.SimpleTask.Application.AccountContext.Commands;
using HttpsRichardy.SimpleTask.Application.AccountContext.Commands.Responses;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries.Responses;
using HttpsRichardy.SimpleTask.Application.Contracts.Services;
using HttpsRichardy.SimpleTask.Infra.Contracts.Security;
using Microsoft.AspNetCore.Identity;

namespace HttpsRichardy.SimpleTask.Infra.Identity.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;

    public AccountService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<AuthenticationQueryResponse> AuthenticateAsync(AuthenticationQuery request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return new AuthenticationQueryResponse
            {
                Sucess = false,
                Message = "Invalid credentials."
            };
        }

        var token = await _jwtService.GenerateTokenAsync(user);
        return new AuthenticationQueryResponse
        {
            Sucess = true,
            Message = "Authentication successful.",
            Token = token
        };
    }

    public async Task<CreateAccountResponse> CreateUserAsync(CreateAccountCommand request)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return new CreateAccountResponse
            {
                Success = true,
                Message = "Account created successfully."
            };
        }
        else
        {
            return new CreateAccountResponse
            {
                Success = false,
                Message = "Error creating account.",
                Errors = result.Errors.Select(error => error.Description).ToList()
            };
        }
    }
}