using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CreateTodoCommand : IRequest<CreateTodoResponse>
{
    public string Title { get; init; } = string.Empty;
}