using FluentValidation;
using HttpsRichardy.SimpleTask.Domain.Exceptions;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Contracts.Repositories;
using MediatR;
using Nelibur.ObjectMapper;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Commands.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IValidator<UpdateTodoCommand> _validator;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IValidator<UpdateTodoCommand> validator)
    {
        _todoRepository = todoRepository;
        _validator = validator;
    }

    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var existingTodo = await _todoRepository.RetrieveByIdAsync(request.TodoId);
        if (existingTodo == null)
            throw new ObjectDoesNotExistException($"The task with ID '{request.TodoId}' does not exist.");

        if (existingTodo.UserId != request.UserId)
            throw new UnauthorizedException();

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        TinyMapper.Map(request, existingTodo);

        await _todoRepository.UpdateAsync(existingTodo);
    }
}
