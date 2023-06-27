using Newtonsoft.Json;

public partial class Pad
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("agency_id")]
    public object AgencyId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("info_url")]
    public object InfoUrl { get; set; }

    [JsonProperty("wiki_url")]
    public string WikiUrl { get; set; }

    [JsonProperty("map_url")]
    public Uri MapUrl { get; set; }

    [JsonProperty("latitude")]
    public string Latitude { get; set; }

    [JsonProperty("longitude")]
    public string Longitude { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("map_image")]
    public Uri MapImage { get; set; }

    [JsonProperty("total_launch_count")]
    public long TotalLaunchCount { get; set; }
}
