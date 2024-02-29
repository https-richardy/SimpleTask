using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries.Handlers;

public class RetrieveAllTodosQueryHandler : IRequestHandler<RetrieveAllTodosQuery, IEnumerable<ToDo>>
{
    private readonly ITodoRepository _todoRepository;

    public RetrieveAllTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<ToDo>> Handle(RetrieveAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.FetchUserTasksAsync(request.UserId);

        if (!string.IsNullOrEmpty(request.Title))
            todos = todos.Where(todo => todo.Title.Contains(request.Title, StringComparison.OrdinalIgnoreCase));

        if (request.IsCompleted)
            todos = todos.Where(todo => todo.Done);

        return await Task.FromResult(todos.ToList());
    }
}