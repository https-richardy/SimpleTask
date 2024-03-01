using FluentValidation;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Models;
using MediatR;
using Nelibur.ObjectMapper;

namespace HttpsRichardy.SimpleTask.Application.TodoContext.Commands.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IValidator<CreateTodoCommand> _validator;

    public CreateTodoCommandHandler(ITodoRepository todoRepository, IValidator<CreateTodoCommand> validator)
    {
        _todoRepository = todoRepository;
        _validator = validator;
    }

    public async Task<CreateTodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var todo = TinyMapper.Map<ToDo>(request);
        await _todoRepository.SaveAsync(todo);

        return new CreateTodoResponse { TodoId = todo.Id, Success = true };
    }
}