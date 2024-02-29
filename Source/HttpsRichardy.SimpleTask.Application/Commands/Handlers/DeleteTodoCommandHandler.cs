using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Exceptions;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands.Handlers;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.RetrieveByIdAsync(request.TodoId);
        if (todo is null)
            throw new ObjectDoesNotExistException($"the task with the ID '{request.TodoId}' does not exist.");

        await _todoRepository.DeleteAsync(todo);
    }
}