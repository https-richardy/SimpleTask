using System.Text;
using HttpsRichardy.SimpleTask.Infra.Contracts.Security;
using HttpsRichardy.SimpleTask.Infra.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

public static class SecurityExtension
{
    public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        # pragma warning disable CS8604
        var secretKey = Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]); /* Possible null reference argument */

        services.AddScoped<IJwtService, JwtService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });

        services.AddAuthorization();
    }
}