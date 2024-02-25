using FluentValidation;
using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Exceptions;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;
using Nelibur.ObjectMapper;

namespace HttpsRichardy.SimpleTask.Application.Commands.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly IRepository<ToDo> _todoRepository;
    private readonly IValidator<UpdateTodoCommand> _validator;

    public UpdateTodoCommandHandler(IRepository<ToDo> todoRepository, IValidator<UpdateTodoCommand> validator)
    {
        _todoRepository = todoRepository;
        _validator = validator;
    }

    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var existingTodo = await _todoRepository.RetrieveByIdAsync(request.TodoId);
        if (existingTodo == null)
            throw new ObjectDoesNotExistException($"The task with ID '{request.TodoId}' does not exist.");

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        TinyMapper.Map(request, existingTodo);

        await _todoRepository.UpdateAsync(existingTodo);
    }
}
