using HttpsRichardy.SimpleTask.Application.Queries.Responses;
using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries.Handlers;

public class RetrieveTodoByIdQueryHandler : IRequestHandler<RetrieveTodoByIdQuery, RetrieveTodoByIdQueryResponse>
{
    private readonly ITodoRepository _todoRepository;

    public RetrieveTodoByIdQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<RetrieveTodoByIdQueryResponse> Handle(RetrieveTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.FetchUserTaskByIdAsync(request.UserId, request.Id);
        return new RetrieveTodoByIdQueryResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            DueDate = todo.DueDate,
            Done = todo.Done,
            Priority = todo.Priority
        };
    }
}