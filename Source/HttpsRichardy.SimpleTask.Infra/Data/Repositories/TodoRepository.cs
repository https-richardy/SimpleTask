using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpsRichardy.SimpleTask.Infra.Data.Repositories;

public class TodoRepository : Repository<ToDo>, ITodoRepository
{
    public TodoRepository(AppDbContext dbContext)
        : base(dbContext) {  }

    # pragma warning disable CS8603
    public async Task<ToDo> FetchUserTaskByIdAsync(string userId, int todoId)
    {
        var retrievedTask = await _dbContext.Users
            .Where(user => user.Id == userId)
            .SelectMany(user => user.Todos)
            .FirstOrDefaultAsync(todo => todo.Id == todoId);

        return retrievedTask;
    }

    public async Task<IEnumerable<ToDo>> FetchUserTasksAsync(string userId)
    {
        var retrievedTasks = await _dbContext.Users
            .Where(user => user.Id == userId)
            .SelectMany(user => user.Todos)
            .ToListAsync();

        return retrievedTasks;
    }
}