using System.Text.Json.Serialization;

namespace HttpsRichardy.SimpleTask.Application.AccountContext.Queries.Responses;

public record AuthenticationQueryResponse
{
    public bool Sucess { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Token { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}