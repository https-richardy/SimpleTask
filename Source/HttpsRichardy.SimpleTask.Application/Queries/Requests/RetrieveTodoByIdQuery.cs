using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries;

public record RetrieveTodoByIdQuery : IRequest<ToDo>
{
    public int Id { get; init; }
    public string UserId { get; init; } = string.Empty;
}