using Newtonsoft.Json;

public partial class Configuration
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("launch_library_id")]
    public object LaunchLibraryId { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("family")]
    public string Family { get; set; }

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("manufacturer")]
    public LaunchServiceProvider Manufacturer { get; set; }

    [JsonProperty("program")]
    public List<object> Program { get; set; }

    [JsonProperty("variant")]
    public string Variant { get; set; }

    [JsonProperty("alias")]
    public string Alias { get; set; }

    [JsonProperty("min_stage")]
    public long MinStage { get; set; }

    [JsonProperty("max_stage")]
    public long MaxStage { get; set; }

    [JsonProperty("length")]
    public object Length { get; set; }

    [JsonProperty("diameter")]
    public object Diameter { get; set; }

    [JsonProperty("maiden_flight")]
    public DateTimeOffset MaidenFlight { get; set; }

    [JsonProperty("launch_mass")]
    public object LaunchMass { get; set; }

    [JsonProperty("leo_capacity")]
    public object LeoCapacity { get; set; }

    [JsonProperty("gto_capacity")]
    public object GtoCapacity { get; set; }

    [JsonProperty("to_thrust")]
    public object ToThrust { get; set; }

    [JsonProperty("apogee")]
    public object Apogee { get; set; }

    [JsonProperty("vehicle_range")]
    public object VehicleRange { get; set; }

    [JsonProperty("image_url")]
    public Uri ImageUrl { get; set; }

    [JsonProperty("info_url")]
    public object InfoUrl { get; set; }

    [JsonProperty("wiki_url")]
    public object WikiUrl { get; set; }

    [JsonProperty("total_launch_count")]
    public long TotalLaunchCount { get; set; }

    [JsonProperty("consecutive_successful_launches")]
    public long ConsecutiveSuccessfulLaunches { get; set; }

    [JsonProperty("successful_launches")]
    public long SuccessfulLaunches { get; set; }

    [JsonProperty("failed_launches")]
    public long FailedLaunches { get; set; }

    [JsonProperty("pending_launches")]
    public long PendingLaunches { get; set; }
}