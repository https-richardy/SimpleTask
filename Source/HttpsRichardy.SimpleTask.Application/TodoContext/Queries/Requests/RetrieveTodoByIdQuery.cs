using HttpsRichardy.SimpleTask.Application.TodoContext.Queries.Responses;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Queries;

public record RetrieveTodoByIdQuery : IRequest<RetrieveTodoByIdQueryResponse>
{
    public int Id { get; init; }
    public string UserId { get; init; } = string.Empty;
}