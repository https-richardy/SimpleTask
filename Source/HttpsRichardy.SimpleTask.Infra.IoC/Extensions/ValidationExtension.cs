using FluentValidation;
using HttpsRichardy.SimpleTask.Application.Commands;
using HttpsRichardy.SimpleTask.Application.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace HttpsRichardy.SimpleTask.Infra.IoC.Extensions;

public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateTodoCommand>, CreateTodoCommandValidator>();;
    }
}