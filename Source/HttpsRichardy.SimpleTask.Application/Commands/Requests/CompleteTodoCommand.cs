using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CompleteTodoCommand : IRequest
{
    public int TodoId { get; init; }
}