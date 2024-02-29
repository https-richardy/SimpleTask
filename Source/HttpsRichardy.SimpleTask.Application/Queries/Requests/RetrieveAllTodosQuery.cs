using HttpsRichardy.SimpleTask.Application.Queries.Responses;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries;

public record RetrieveAllTodosQuery : IRequest<IEnumerable<RetrieveAllTodosQueryResponse>>
{
    public string Title { get; init; } = string.Empty;
    public string UserId { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
}