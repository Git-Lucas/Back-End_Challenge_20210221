using Newtonsoft.Json;

public partial class LaunchServiceProvider
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("featured")]
    public bool Featured { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("abbrev")]
    public string Abbrev { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("administrator")]
    public object Administrator { get; set; }

    [JsonProperty("founding_year")]
    public long FoundingYear { get; set; }

    [JsonProperty("launchers")]
    public string Launchers { get; set; }

    [JsonProperty("spacecraft")]
    public string Spacecraft { get; set; }

    [JsonProperty("launch_library_url")]
    public Uri LaunchLibraryUrl { get; set; }

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

    [JsonProperty("consecutive_successful_landings")]
    public long ConsecutiveSuccessfulLandings { get; set; }

    [JsonProperty("successful_landings")]
    public long SuccessfulLandings { get; set; }

    [JsonProperty("failed_landings")]
    public long FailedLandings { get; set; }

    [JsonProperty("attempted_landings")]
    public long AttemptedLandings { get; set; }

    [JsonProperty("info_url")]
    public string InfoUrl { get; set; }

    [JsonProperty("wiki_url")]
    public Uri WikiUrl { get; set; }

    [JsonProperty("logo_url")]
    public Uri LogoUrl { get; set; }

    [JsonProperty("image_url")]
    public Uri ImageUrl { get; set; }

    [JsonProperty("nation_url")]
    public Uri NationUrl { get; set; }
}
