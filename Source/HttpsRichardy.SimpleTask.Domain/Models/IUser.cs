namespace HttpsRichardy.SimpleTask.Domain.Models;

public interface IUser
{
    public string Id { get; }
    public string? UserName { get; }
    public string? Email { get; }
    public string? PasswordHash { get; }
}