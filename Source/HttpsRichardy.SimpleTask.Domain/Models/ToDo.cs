using HttpsRichardy.SimpleTask.Domain.Models.Enums;

namespace HttpsRichardy.SimpleTask.Domain.Models;

# pragma warning disable CS8618
public record ToDo : Model
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool Done { get; set; } = false;
    public IUser User { get; set; }
    public Priority? Priority { get; set; }
}