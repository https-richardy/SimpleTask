using System.ComponentModel.DataAnnotations;
using HttpsRichardy.SimpleTask.Domain.Models.Enums;

namespace HttpsRichardy.SimpleTask.WebUI.ViewModels;

public record CreateTodoViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title must not exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(180, ErrorMessage = "Description must not exceed 180 charactes.")]
    public string? Description { get; set; } = string.Empty;
    public Priority? Priority { get; set; }
    public DateTime? DueDate { get; set; }

    public CreateTodoViewModel()
    {

    }

    public CreateTodoViewModel(string title, string? description, Priority? priority, DateTime? dueDate)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
    }
}