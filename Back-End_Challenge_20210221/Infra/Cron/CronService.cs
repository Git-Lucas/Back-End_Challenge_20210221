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
        public int Take = 100;
        public int Skip = 0;

        public CronService(ILogger<CronService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ImportRange = new TimeSpan(23, 19, 00) - DateTime.UtcNow.TimeOfDay;
            _logger.LogInformation($"StartAsync {DateTime.UtcNow}");
            //Timer = new Timer(ImportData, null, ImportRange, TimeSpan.FromSeconds(5));
            Timer = new Timer(ImportData, null, TimeSpan.FromDays(1), TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public async void ImportData(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://ll.thespacedevs.com/2.0.0/")
                };

                var response = await _httpClient.GetAsync($"launch/?limit={Take}&offset={Skip}");
                var jsonString = await response.Content.ReadAsStringAsync();

                dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonString)!;
                obj = JsonConvert.SerializeObject(obj.results);

                List<Launch> launchers = JsonConvert.DeserializeObject<List<Launch>>(obj);

                var scopedService = scope.ServiceProvider.GetRequiredService<ILaunchData>();
                foreach (Launch l in launchers)
                {
                    l.Imported_T = DateTime.UtcNow;
                    l.Status = Import_Status.Draft;
                    await scopedService.CreateAsync(l);
                }

                _logger.LogInformation($"Importados 100 registros! {DateTime.Now}");

                Skip += 100;
                if (Skip == 200)
                    await StopAsync(new CancellationToken());
            }
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
