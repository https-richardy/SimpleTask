using HttpsRichardy.SimpleTask.Domain.Models;

namespace HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;

public interface ITodoRepository : IRepository<ToDo>
{
    Task<IEnumerable<ToDo>> FetchUserTasksAsync(string userId);
    Task<ToDo> FetchUserTaskByIdAsync(string userId, int todoId);
}