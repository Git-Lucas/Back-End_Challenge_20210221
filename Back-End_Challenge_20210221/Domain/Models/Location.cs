using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Location
{
    public long Id { get; set; }

    public Uri? Url { get; set; }

    public string? Name { get; set; }

    [JsonProperty("country_code")]
    public string? CountryCode { get; set; }

    [JsonProperty("map_image")]
    public Uri? MapImage { get; set; }

    [JsonProperty("total_launch_count")]
    public long TotalLaunchCount { get; set; }

    [JsonProperty("total_landing_count")]
    public long TotalLandingCount { get; set; }
}