using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries;

public record RetrieveAllTodosQuery : IRequest<IEnumerable<ToDo>>
{
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
}