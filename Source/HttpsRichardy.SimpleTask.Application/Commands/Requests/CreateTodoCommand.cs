using HttpsRichardy.SimpleTask.Domain.TodoContext.Models.Enums;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CreateTodoCommand : IRequest<CreateTodoResponse>
{
    public string UserId { get; set; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime? DueDate { get; init; }
    public Priority? Priority { get; init; }
}