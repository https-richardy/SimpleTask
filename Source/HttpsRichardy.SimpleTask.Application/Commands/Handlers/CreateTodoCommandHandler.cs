using FluentValidation;
using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;
using Nelibur.ObjectMapper;

namespace HttpsRichardy.SimpleTask.Application.Commands.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly IRepository<ToDo> _todoRepository;
    private readonly IValidator<CreateTodoCommand> _validator;

    public CreateTodoCommandHandler(IRepository<ToDo> todoRepository, IValidator<CreateTodoCommand> validator)
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