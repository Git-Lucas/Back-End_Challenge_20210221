using Back_End_Challenge_20210221.Domain.Models;

namespace Back_End_Challenge_20210221.Domain.Data;

public interface ILaunchData
{
    Task<int> CountAsync();
    Task<int> CountUnlikeTrashAsync();
    Task CreateAsync(Launch launch);
    Task<T> CreateUniqueAsync<T>(T obj, long id);
    Task<Launch> GetAsync(Guid id);
    Task<List<Launch>> GetAllAsync(int skip, int take);
    Task PutAsync(Guid id, Launch launch);
    Task DeleteAsync(Guid id);
    Task DeleteAllAsync();
}
