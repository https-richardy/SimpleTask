using HttpsRichardy.SimpleTask.Infra.IoC.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HttpsRichardy.SimpleTask.Infra.IoC;

public static class DependencyContainer
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataPersistence(configuration);

        services.AddMediator();
        services.AddValidation();
        services.AddMapping();
    }
}