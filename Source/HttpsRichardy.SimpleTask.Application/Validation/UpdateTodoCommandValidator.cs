using FluentValidation;
using HttpsRichardy.SimpleTask.Application.Commands;

namespace HttpsRichardy.SimpleTask.Application.Validation;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>, IValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
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