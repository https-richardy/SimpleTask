using HttpsRichardy.SimpleTask.Domain.Exceptions;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Contracts.Repositories;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Commands.Handlers;

public class CompleteTodoCommandHandler : IRequestHandler<CompleteTodoCommand>
{
    private readonly ITodoRepository _todoRepository;

    public CompleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.RetrieveByIdAsync(request.TodoId);
        if (todo is null)
            throw new ObjectDoesNotExistException($"the task with the ID '{request.TodoId}' does not exist.");

        if (todo.UserId != request.UserId)
            throw new UnauthorizedException();

        todo.Done = true;

        await _todoRepository.UpdateAsync(todo);
    }
}