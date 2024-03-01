using HttpsRichardy.SimpleTask.Domain.Shared.Models;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Models.Enums;

namespace HttpsRichardy.SimpleTask.Domain.TodoContext.Models;

public record ToDo : Model
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool Done { get; set; } = false;
    public string UserId { get; set; } = string.Empty;
    public Priority? Priority { get; set; }
}