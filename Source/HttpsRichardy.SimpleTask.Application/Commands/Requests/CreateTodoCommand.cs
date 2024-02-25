using HttpsRichardy.SimpleTask.Domain.Models.Enums;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CreateTodoCommand : IRequest<CreateTodoResponse>
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime? DueDate { get; init; }
    public Priority? Priority { get; init; }
}