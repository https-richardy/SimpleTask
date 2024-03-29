using HttpsRichardy.SimpleTask.Domain.Shared.Models;

namespace HttpsRichardy.SimpleTask.Domain.Shared.Contracts.Repositories;

public interface IRepository<TModel> where TModel : Model
{
    Task SaveAsync(TModel model);
    Task DeleteAsync(TModel model);
    Task UpdateAsync(TModel model);
    Task<TModel> RetrieveByIdAsync(int id);
    Task<TModel> RetrieveByIdAsync(string id);
    Task<IEnumerable<TModel>> RetrieveAllAsync();
}