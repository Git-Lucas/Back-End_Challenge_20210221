using Back_End_Challenge_20210221.Domain.Models.Enums;
using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Launch
{
    public Guid Id { get; set; }

    public Uri? Url { get; set; }

    [JsonProperty("launch_library_id")]
    public long? LaunchLibraryId { get; set; }

    public string? Slug { get; set; }

    public string? Name { get; set; }

    [JsonProperty("status")]
    public Status? StatusLaunch { get; set; }

    public DateTime? Net { get; set; }

    [JsonProperty("window_end")]
    public DateTime? WindowEnd { get; set; }

    [JsonProperty("window_start")]
    public DateTime? WindowStart { get; set; }

    public bool Inhold { get; set; }

    public bool Tbdtime { get; set; }

    public bool Tbddate { get; set; }

    public long? Probability { get; set; }

    public string? Holdreason { get; set; }

    public string? Failreason { get; set; }

    public string? Hashtag { get; set; }

    [JsonProperty("launch_service_provider")]
    public LaunchServiceProvider? LaunchServiceProvider { get; set; }

    public Rocket? Rocket { get; set; }

    public Mission? Mission { get; set; }

    public Pad? Pad { get; set; }

    [JsonProperty("webcast_live")]
    public bool WebcastLive { get; set; }

    public Uri? Image { get; set; }

    public Uri? Infographic { get; set; }

    public List<Program> Program { get; set; } = new();

    public DateTime Imported_T { get; set; }

    public Import_Status Status { get; set; }
}