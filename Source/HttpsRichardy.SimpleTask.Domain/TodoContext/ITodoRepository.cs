using HttpsRichardy.SimpleTask.Domain.Shared.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.TodoContext.Models;

namespace HttpsRichardy.SimpleTask.Domain.TodoContext.Contracts.Repositories;

public interface ITodoRepository : IRepository<ToDo>
{
    Task<IEnumerable<ToDo>> FetchUserTasksAsync(string userId);
    Task<ToDo> FetchUserTaskByIdAsync(string userId, int todoId);
}