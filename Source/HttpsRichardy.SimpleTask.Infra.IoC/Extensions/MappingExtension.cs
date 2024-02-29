using HttpsRichardy.SimpleTask.Application.Commands;
using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;

namespace HttpsRichardy.SimpleTask.Infra.IoC.Extensions;

public static class MappingExtension
{
    public static void AddMapping(this IServiceCollection services)
    {
        TinyMapper.Bind<CreateTodoCommand, ToDo>(cfg =>
        {
            cfg.Bind(src => src.Title, target => target.Title);
            cfg.Bind(src => src.Description, target => target.Description);
            cfg.Bind(src => src.DueDate, target => target.DueDate);
            cfg.Bind(src => src.Priority, target => target.Priority);
            cfg.Bind(src => src.UserId, target => target.UserId);
        });

        TinyMapper.Bind<UpdateTodoCommand, ToDo>(cfg =>
        {
            cfg.Bind(src => src.Title, target => target.Title);
            cfg.Bind(src => src.Description, target => target.Description);
            cfg.Bind(src => src.DueDate, target => target.DueDate);
            cfg.Bind(src => src.Priority, target => target.Priority);
        });
    }
}