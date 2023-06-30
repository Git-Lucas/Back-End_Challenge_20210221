using Back_End_Challenge_20210221.Domain.Models;

namespace Back_End_Challenge_20210221.Domain.Data
{
    public interface ILaunchData
    {
        Task CreateAsync(Launch launch);
        Task CreateAsync(List<Launch> launchers);
        Task<Launch> GetAsync(Guid id);
        Task<List<Launch>> GetAllAsync(int skip = 0, int take = 10);
        Task PutAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
