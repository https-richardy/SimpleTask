using FluentValidation;
using HttpsRichardy.SimpleTask.Application.AccountContext.Commands;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries;
using HttpsRichardy.SimpleTask.Application.AccountContext.Validation;
using HttpsRichardy.SimpleTask.Application.TodoContext.Commands;
using HttpsRichardy.SimpleTask.Application.TodoContext.Validation;
using HttpsRichardy.SimpleTask.Application.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace HttpsRichardy.SimpleTask.Infra.IoC.Extensions;

public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateTodoCommand>, CreateTodoCommandValidator>();
        services.AddScoped<IValidator<UpdateTodoCommand>, UpdateTodoCommandValidator>();

        # region Account validators

        services.AddScoped<IValidator<CreateAccountCommand>, CreateAccountCommandValidator>();
        services.AddScoped<IValidator<AuthenticationQuery>, AuthenticationQueryValidator>();

        # endregion
    }
}