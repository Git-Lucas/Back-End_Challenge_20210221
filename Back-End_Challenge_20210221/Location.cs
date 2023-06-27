using Newtonsoft.Json;

public partial class Location
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("map_image")]
    public Uri MapImage { get; set; }

    [JsonProperty("total_launch_count")]
    public long TotalLaunchCount { get; set; }

    [JsonProperty("total_landing_count")]
    public long TotalLandingCount { get; set; }
}
