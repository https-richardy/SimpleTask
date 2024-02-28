using HttpsRichardy.SimpleTask.Infra.Identity;

namespace HttpsRichardy.SimpleTask.Infra.Contracts.Security;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(ApplicationUser user);
}