using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Queries.Handlers;

public class RetrieveTodoByIdQueryHandler : IRequestHandler<RetrieveTodoByIdQuery, ToDo>
{
    private readonly ITodoRepository _todoRepository;

    public RetrieveTodoByIdQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<ToDo> Handle(RetrieveTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.FetchUserTaskByIdAsync(request.UserId, request.Id);
        return todo;
    }
}