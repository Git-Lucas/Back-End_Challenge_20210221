using Newtonsoft.Json;

public class Launch
{
    public Guid Id { get; set; }

    public Uri Url { get; set; }

    [JsonProperty("launch_library_id")]
    public long? LaunchLibraryId { get; set; }

    public string Slug { get; set; }

    public string Name { get; set; }

    public Status Status { get; set; }

    public DateTime Net { get; set; }

    [JsonProperty("window_end")]
    public DateTime WindowEnd { get; set; }

    [JsonProperty("window_start")]
    public DateTime WindowStart { get; set; }

    public bool Inhold { get; set; }

    public bool Tbdtime { get; set; }

    public bool Tbddate { get; set; }

    public long? Probability { get; set; }

    public string Holdreason { get; set; }

    public string Failreason { get; set; }

    public string Hashtag { get; set; }

    [JsonProperty("launch_service_provider")]
    public LaunchServiceProvider LaunchServiceProvider { get; set; }

    public Rocket Rocket { get; set; }

    public object Mission { get; set; }

    public Pad Pad { get; set; }

    [JsonProperty("webcast_live")]
    public bool WebcastLive { get; set; }

    public object Image { get; set; }

    public object Infographic { get; set; }

    public List<object> Program { get; set; }
}
