namespace HttpsRichardy.SimpleTask.Domain.Models;

public record ToDo : Model
{
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; } = false;
}