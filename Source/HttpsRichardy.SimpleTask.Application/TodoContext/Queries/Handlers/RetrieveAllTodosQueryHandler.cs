using HttpsRichardy.SimpleTask.Application.TodoContext.Queries.Responses;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Contracts.Repositories;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Queries.Handlers;

public class RetrieveAllTodosQueryHandler : IRequestHandler<RetrieveAllTodosQuery, IEnumerable<RetrieveAllTodosQueryResponse>>
{
    private readonly ITodoRepository _todoRepository;

    public RetrieveAllTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<RetrieveAllTodosQueryResponse>> Handle(RetrieveAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.FetchUserTasksAsync(request.UserId);

        if (!string.IsNullOrEmpty(request.Title))
            todos = todos.Where(todo => todo.Title.Contains(request.Title, StringComparison.OrdinalIgnoreCase));

        if (request.IsCompleted)
            todos = todos.Where(todo => todo.Done);

        var responseList = todos.Select(todo => new RetrieveAllTodosQueryResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            DueDate = todo.DueDate,
            Done = todo.Done,
            Priority = todo.Priority
        }).ToList();

        return responseList;
    }
}