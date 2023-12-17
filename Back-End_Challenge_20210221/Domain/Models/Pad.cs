using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Pad
{
    public long Id { get; set; }

    public Uri? Url { get; set; }

    [JsonProperty("agency_id")]
    public long? AgencyId { get; set; }

    public string? Name { get; set; }

    [JsonProperty("info_url")]
    public Uri? InfoUrl { get; set; }

    [JsonProperty("wiki_url")]
    public string? WikiUrl { get; set; }

    [JsonProperty("map_url")]
    public Uri? MapUrl { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public Location? Location { get; set; }

    [JsonProperty("map_image")]
    public Uri? MapImage { get; set; }

    [JsonProperty("total_launch_count")]
    public long? TotalLaunchCount { get; set; }
}