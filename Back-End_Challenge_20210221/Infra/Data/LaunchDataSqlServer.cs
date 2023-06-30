using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End_Challenge_20210221.Infra.Data
{
    public class LaunchDataSqlServer : ILaunchData
    {
        private readonly EfSqlServerAdapter _context;

        public LaunchDataSqlServer(EfSqlServerAdapter context)
        {
            _context = context;
        }

        public async Task CreateAsync(Launch launch)
        {
            await _context.AddAsync(launch);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(List<Launch> launchers)
        {
            await _context.AddRangeAsync(launchers);
            await _context.SaveChangesAsync();
        }

        public async Task<Launch> GetAsync(Guid id)
        {
            var launch = await _context.Launchers.Include(x => x.StatusLaunch)
                                               .Include(x => x.LaunchServiceProvider)
                                               .Include(x => x.Rocket)
                                               .ThenInclude(x => x.Configuration)
                                               .Include(x => x.Pad)
                                               .ThenInclude(x => x.Location)
                                               .SingleOrDefaultAsync(x => x.Id == id);

            if (launch is not null)
            {
                return launch;
            }
            else
            {
                throw new Exception("Não encontrado!");
            }
        }

        public async Task<List<Launch>> GetAllAsync(int skip, int take)
        {
            var launchers = await _context.Launchers
                                                .Include(x => x.StatusLaunch)
                                                .Include(x => x.LaunchServiceProvider)
                                                .Include(x => x.Rocket)
                                                .ThenInclude(x => x.Configuration)
                                                .Include(x => x.Pad)
                                                .ThenInclude(x => x.Location)
                                                .Skip(skip)
                                                .Take(take)
                                                .ToListAsync();

            return launchers;
        }

        public Task PutAsync(Guid id)
        {
            throw new Exception("Não Implementado");
        }

        public async Task DeleteAsync(Guid id)
        {
            var launch = await _context.Launchers.FirstOrDefaultAsync(x => x.Id == id);

            if (launch is not null)
            {
                _context.Launchers.Remove(launch);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Não encontrado!");
            }
        }
    }
}
