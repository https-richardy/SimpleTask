using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly IRepository<ToDo> _todoRepository;

    public CreateTodoCommandHandler(IRepository<ToDo> todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<CreateTodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        ToDo todo = new ToDo { Title = request.Title };
        await _todoRepository.SaveAsync(todo);

        return new CreateTodoResponse { TodoId = todo.Id, Success = true };
    }
}