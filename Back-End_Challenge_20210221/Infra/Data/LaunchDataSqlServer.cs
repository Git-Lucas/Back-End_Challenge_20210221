using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Back_End_Challenge_20210221.Infra.Data
{
    public class LaunchDataSqlServer : ILaunchData
    {
        private readonly EfSqlServerAdapter _context;

        public LaunchDataSqlServer(EfSqlServerAdapter context)
        {
            _context = context;
        }

        public async Task<int> CountAsync() => await _context.Launchers.CountAsync();

        public async Task CreateAsync(Launch launch)
        {
            var existingLaunch = await _context.Launchers.FirstOrDefaultAsync(x => x.Id == launch.Id);

            if (existingLaunch is null)
            {
                if (launch.StatusLaunch is not null)
                    launch.StatusLaunch = await CreateUniqueAsync(
                        launch.StatusLaunch, launch.StatusLaunch.Id);

                if (launch.LaunchServiceProvider is not null)
                    launch.LaunchServiceProvider = await CreateUniqueAsync(
                        launch.LaunchServiceProvider, launch.LaunchServiceProvider.Id);

                if (launch.Rocket is not null)
                {
                    if (launch.Rocket.Configuration is not null)
                        launch.Rocket.Configuration = await CreateUniqueAsync(
                            launch.Rocket.Configuration, launch.Rocket.Configuration.Id);

                    launch.Rocket = await CreateUniqueAsync(
                        launch.Rocket, launch.Rocket.Id);
                }

                if (launch.Mission is not null)
                {
                    if (launch.Mission.Orbit is not null)
                        launch.Mission.Orbit = await CreateUniqueAsync(
                            launch.Mission.Orbit, launch.Mission.Orbit.Id);

                    launch.Mission = await CreateUniqueAsync(
                        launch.Mission, launch.Mission.Id);
                }

                if (launch.Pad is not null)
                {
                    if (launch.Pad.Location is not null)
                        launch.Pad.Location = await CreateUniqueAsync(
                            launch.Pad.Location, launch.Pad.Location.Id);

                    launch.Pad = await CreateUniqueAsync(
                        launch.Pad, launch.Pad.Id);
                }

                if (launch.Program is not null)
                {
                    var programs = new List<Domain.Models.Program>();
                    foreach (Domain.Models.Program p in launch.Program)
                    {
                        if (p.Agencies is not null)
                        {
                            var agencies = new List<Agency>();
                            foreach (Agency a in p.Agencies)
                                agencies.Add(await CreateUniqueAsync(a, a.Id));

                            p.Agencies = agencies;
                        }
                        programs.Add(await CreateUniqueAsync(p, p.Id));
                    }
                    launch.Program = programs;
                }

                await _context.AddAsync(launch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> CreateUniqueAsync<T>(T obj, long id)
        {
            var existingObj = await _context.FindAsync(typeof(T), id);

            if (existingObj is null)
            {
                await _context.AddAsync(obj!);
                await _context.SaveChangesAsync();
                existingObj = await _context.FindAsync(typeof(T), id);
            }

            return (T)existingObj!;
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

        public async Task PutAsync(Guid id, Launch launch)
        {
            var launchDatabase = await _context.Launchers.AsNoTracking()
                                                         .SingleOrDefaultAsync(x => x.Id == id);

            if (launchDatabase is not null)
            {
                _context.Launchers.Update(launch);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Não encontrado!");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var launch = await GetAsync(id);
                _context.Launchers.Remove(launch);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
