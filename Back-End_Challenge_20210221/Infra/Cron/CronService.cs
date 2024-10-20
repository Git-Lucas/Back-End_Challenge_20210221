using Newtonsoft.Json;
using System.Dynamic;
using Back_End_Challenge_20210221.Domain.Models;
using Back_End_Challenge_20210221.Domain.Models.Enums;
using Back_End_Challenge_20210221.Domain.Data;

namespace Back_End_Challenge_20210221.Infra.Cron;

public class CronService : IHostedService, IDisposable
{
    private readonly ILogger<CronService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private Timer? _timer;
    private readonly TimeSpan _importRange = TimeSpan.FromMinutes(5);
    private readonly int _importLimit = 2000;
    private readonly int _take = 100;
    private int _skip = 0;
    private int _iterations;
    private readonly HttpClient _httpClient;

    public CronService(ILogger<CronService> logger, IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(configuration["TheSpaceDevsBaseAddress"] 
                ?? throw new InvalidOperationException("TheSpaceDevsBaseAddress not found in configuration file."))
        };
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StartAsync {UtcNow}. Init in {ImportRange} minutes", DateTime.UtcNow, _importRange.TotalMinutes);
        _iterations = _importLimit / _take;
        _timer = new Timer(ImportData, null, _importRange, TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    private async void ImportData(object? state)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        ILaunchData scopedService = scope.ServiceProvider.GetRequiredService<ILaunchData>();
        int countApiTheSpaceDevs = await GetCountApiTheSpaceDevs();

        for (int i = 1; i <= _iterations; i++)
        {
            var response = await _httpClient.GetAsync($"launch/?limit={_take}&offset={_skip}");
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

            _skip = _skip + _take > countApiTheSpaceDevs ? 0 : _skip + _take;

            _logger.LogInformation("Imported {RecordCount} records! {UtcNow}", i * _take, DateTime.Now);

            await Task.Delay(_importRange);
        }
    }

    private async Task<int> GetCountApiTheSpaceDevs()
    {
        var response = await _httpClient.GetAsync($"launch/?limit=1&offset=0");
        var jsonString = await response.Content.ReadAsStringAsync();

        dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonString)!;
        obj = JsonConvert.SerializeObject(obj.count);

        return JsonConvert.DeserializeObject<int>(obj);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StopAsync {UtcNow}", DateTime.UtcNow);
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _timer?.Dispose();
    }
}
