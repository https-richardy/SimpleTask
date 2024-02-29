using HttpsRichardy.SimpleTask.Application.Contracts.Services;
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
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<UserManager<ApplicationUser>>();
    }
}