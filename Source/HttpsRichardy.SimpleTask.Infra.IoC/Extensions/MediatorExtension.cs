using System.Reflection;
using HttpsRichardy.SimpleTask.Application.Commands;
using HttpsRichardy.SimpleTask.Application.Commands.Handlers;
using HttpsRichardy.SimpleTask.Application.Queries;
using HttpsRichardy.SimpleTask.Application.Queries.Handlers;
using HttpsRichardy.SimpleTask.Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HttpsRichardy.SimpleTask.Infra.IoC.Extensions;

public static class MediatorExtension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddTransient<IRequestHandler<CreateTodoCommand, CreateTodoResponse>, CreateTodoCommandHandler>();
        services.AddTransient<IRequestHandler<CompleteTodoCommand>, CompleteTodoCommandHandler>();

        services.AddTransient<IRequestHandler<RetrieveAllTodosQuery, IEnumerable<ToDo>>, RetrieveAllTodosQueryHandler>();
        services.AddTransient<IRequestHandler<RetrieveTodoByIdQuery, ToDo>, RetrieveTodoByIdQueryHandler>();
    }
}