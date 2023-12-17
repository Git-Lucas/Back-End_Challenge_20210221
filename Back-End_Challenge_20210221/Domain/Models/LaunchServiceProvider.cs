namespace Back_End_Challenge_20210221.Domain.Models;

public class LaunchServiceProvider
{
    public long Id { get; set; }

    public Uri? Url { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }
}