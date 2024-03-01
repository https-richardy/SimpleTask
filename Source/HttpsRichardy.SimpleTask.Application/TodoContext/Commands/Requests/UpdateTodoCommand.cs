using HttpsRichardy.SimpleTask.Domain.TodoContext.Models.Enums;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Commands;

public record UpdateTodoCommand : IRequest
{
    public string UserId { get; set; } = string.Empty;
    public int TodoId { get; set; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime? DueDate { get; init; }
    public Priority? Priority { get; init; }
}