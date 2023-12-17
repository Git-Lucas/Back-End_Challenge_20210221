using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Configuration
{
    public long Id { get; set; }

    [JsonProperty("launch_library_id")]
    public long? LaunchLibraryId { get; set; }

    public Uri? Url { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    [JsonProperty("full_name")]
    public string? FullName { get; set; }

    public string? Variant { get; set; }
}