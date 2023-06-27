using Newtonsoft.Json;

public partial class Mission
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("launch_library_id")]
    public object LaunchLibraryId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("launch_designator")]
    public object LaunchDesignator { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("orbit")]
    public Orbit Orbit { get; set; }
}
