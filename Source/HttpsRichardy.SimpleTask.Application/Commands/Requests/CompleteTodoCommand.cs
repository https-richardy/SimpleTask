using MediatR;

namespace HttpsRichardy.SimpleTask.Application.Commands;

public record CompleteTodoCommand : IRequest
{
    public int TodoId { get; init; }
    public string UserId { get; init; } = string.Empty;
}