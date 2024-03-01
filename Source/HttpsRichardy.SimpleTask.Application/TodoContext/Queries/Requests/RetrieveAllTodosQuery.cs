using HttpsRichardy.SimpleTask.Application.TodoContext.Queries.Responses;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Queries;

public record RetrieveAllTodosQuery : IRequest<IEnumerable<RetrieveAllTodosQueryResponse>>
{
    public string Title { get; init; } = string.Empty;
    public string UserId { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
}