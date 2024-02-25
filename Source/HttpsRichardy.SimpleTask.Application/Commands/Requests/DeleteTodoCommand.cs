using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record DeleteTodoCommand : IRequest
{
    public int TodoId { get; init; }
}