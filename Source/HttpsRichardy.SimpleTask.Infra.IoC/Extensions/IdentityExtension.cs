using HttpsRichardy.SimpleTask.Application.Contracts.Services;
using HttpsRichardy.SimpleTask.Domain.Models;
using HttpsRichardy.SimpleTask.Infra.Data;
using HttpsRichardy.SimpleTask.Infra.Identity;
using HttpsRichardy.SimpleTask.Infra.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HttpsRichardy.SimpleTask.Infra.IoC.Extensions;

public static class IdentityServicesExtension
{
    public static void AddIdentityServices(this IServiceCollection services)
    {
        services.AddScoped<IUser, ApplicationUser>();

        services.AddScoped<IAccountService, AccountService>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<UserManager<ApplicationUser>>();
    }
}