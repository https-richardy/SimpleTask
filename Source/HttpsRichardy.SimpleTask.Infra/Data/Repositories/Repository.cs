using Microsoft.EntityFrameworkCore;
using HttpsRichardy.SimpleTask.Domain.Contracts.Repositories;
using HttpsRichardy.SimpleTask.Domain.Models;

namespace HttpsRichardy.SimpleTask.Infra.Data.Repositories;

public class Repository<TModel> : IRepository<TModel> where TModel : Model
{
    protected readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public virtual async Task SaveAsync(TModel model)
    {
        await _dbContext.Set<TModel>().AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TModel model)
    {
        _dbContext.Set<TModel>().Remove(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TModel model)
    {
        var existingModel = await _dbContext.Set<TModel>().FindAsync(model.Id);

        if (existingModel != null)
        {
            _dbContext.Entry(existingModel).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
        }

        _dbContext.Entry(model).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    # pragma warning disable CS8603
    public virtual async Task<TModel> RetrieveByIdAsync(int id)
    {
        return await _dbContext.Set<TModel>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<TModel>> RetrieveAllAsync()
    {
        return await _dbContext.Set<TModel>().ToListAsync();
    }

    public async Task<TModel> RetrieveByIdAsync(string id)
    {
        return await _dbContext.Set<TModel>().FindAsync(id);
    }
}