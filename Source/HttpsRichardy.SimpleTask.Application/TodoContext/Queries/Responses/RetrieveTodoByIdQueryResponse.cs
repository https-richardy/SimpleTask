using HttpsRichardy.SimpleTask.Domain.TodoContext.Models.Enums;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Queries.Responses;

public record RetrieveTodoByIdQueryResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool Done { get; set; } = false;
    public Priority? Priority { get; set; }
}