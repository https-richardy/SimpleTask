using HttpsRichardy.SimpleTask.Application.Queries.Responses;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries;

public record RetrieveTodoByIdQuery : IRequest<RetrieveTodoByIdQueryResponse>
{
    public int Id { get; init; }
    public string UserId { get; init; } = string.Empty;
}