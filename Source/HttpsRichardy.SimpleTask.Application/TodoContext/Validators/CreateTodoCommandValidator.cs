using FluentValidation;
using HttpsRichardy.SimpleTask.Application.TodoContext.Commands;


namespace HttpsRichardy.SimpleTask.Application.TodoContext.Validation;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>, IValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(command => command.Description)
            .MaximumLength(180).WithMessage("Description must not exceed 180 charactes");

        RuleFor(command => command.DueDate)
            .Must(date => date == null|| date >= DateTime.UtcNow)
            .WithMessage("Due date must be in the future, or not provided.");

        RuleFor(command => command.Priority)
            .IsInEnum().WithMessage("Invalid priority value.");
    }
}