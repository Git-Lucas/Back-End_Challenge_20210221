using Newtonsoft.Json;
using System.Dynamic;
using Back_End_Challenge_20210221.Domain.Models;
using Back_End_Challenge_20210221.Domain.Models.Enums;
using Back_End_Challenge_20210221.Domain.Data;

namespace Back_End_Challenge_20210221.Infra.Cron
{
    public class CronService : IHostedService, IDisposable
    {
        private readonly ILogger<CronService> _logger;
        private readonly IServiceProvider _serviceProvider;
        public Timer? Timer;
        public TimeSpan ImportRange;
        public int ImportLimit = 2000;
        public int Take = 100;
        public int Skip = 0;
        public int Iterations;
        public HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://ll.thespacedevs.com/2.0.0/")
        };
        public int CountApiTheSpaceDevs;

        public CronService(ILogger<CronService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ImportRange = new TimeSpan(05, 53, 00) - DateTime.UtcNow.TimeOfDay;
            _logger.LogInformation($"StartAsync {DateTime.UtcNow}");
            Iterations = ImportLimit / Take;
            Timer = new Timer(ImportData, null, ImportRange, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public async void ImportData(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<ILaunchData>();
                CountApiTheSpaceDevs = await GetCountApiTheSpaceDevs(scopedService);

                for (int i = 1; i <= Iterations; i++)
                {
                    var response = await HttpClient.GetAsync($"launch/?limit={Take}&offset={Skip}");
                    var jsonString = await response.Content.ReadAsStringAsync();

                    dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonString)!;
                    obj = JsonConvert.SerializeObject(obj.results);

                    List<Launch> launchers = JsonConvert.DeserializeObject<List<Launch>>(obj);

                    foreach (Launch l in launchers)
                    {
                        l.Imported_T = DateTime.UtcNow;
                        l.Status = Import_Status.Draft;
                        await scopedService.CreateAsync(l);
                    }

                    Skip = Skip + Take > CountApiTheSpaceDevs ? 0 : Skip + Take;

                    _logger.LogInformation($"Imported {i * Take} records! {DateTime.Now}");

                    await Task.Delay(TimeSpan.FromMinutes(5));
                }
            }
        }

        private async Task<int> GetCountApiTheSpaceDevs(ILaunchData scopedService)
        {
            var response = await HttpClient.GetAsync($"launch/?limit=1&offset=0");
            var jsonString = await response.Content.ReadAsStringAsync();

            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonString)!;
            obj = JsonConvert.SerializeObject(obj.count);

            return JsonConvert.DeserializeObject<int>(obj);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"StopAsync {DateTime.UtcNow}");
            Timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => Timer?.Dispose();
    }
}
