using Newtonsoft.Json;

public partial class Launch
{
    public Guid Id { get; set; }

    public Uri Url { get; set; }

    [JsonProperty("launch_library_id")]
    public object LaunchLibraryId { get; set; }

    public string Slug { get; set; }

    public string Name { get; set; }

    public Status Status { get; set; }

    public DateTimeOffset Net { get; set; }

    public DateTimeOffset WindowEnd { get; set; }

    public DateTimeOffset WindowStart { get; set; }

    public bool Inhold { get; set; }

    public bool Tbdtime { get; set; }

    public bool Tbddate { get; set; }

    public object Probability { get; set; }

    public object Holdreason { get; set; }

    public object Failreason { get; set; }

    public object Hashtag { get; set; }

    public LaunchServiceProvider Launch_Service_Provider { get; set; }

    public Rocket Rocket { get; set; }

    public Mission Mission { get; set; }

    public Pad Pad { get; set; }

    public List<object> InfoUrLs { get; set; }

    public List<object> VidUrLs { get; set; }

    public bool Webcast_Live { get; set; }

    public Uri Image { get; set; }

    public object Infographic { get; set; }

    public List<object> Program { get; set; }
}
