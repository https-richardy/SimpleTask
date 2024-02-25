using HttpsRichardy.SimpleTask.Domain.Models.Enums;

namespace HttpsRichardy.SimpleTask.Domain.Models;

public record ToDo : Model
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool Done { get; set; } = false;
    public Priority Priority { get; set; }
}