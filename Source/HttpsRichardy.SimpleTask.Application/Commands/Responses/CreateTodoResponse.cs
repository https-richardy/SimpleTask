using System.Text.Json.Serialization;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CreateTodoResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int TodoId { get; init; }
    public bool Success { get; init; }
}