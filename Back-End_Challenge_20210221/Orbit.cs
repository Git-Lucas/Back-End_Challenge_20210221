using Newtonsoft.Json;

public partial class Orbit
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("abbrev")]
    public string Abbrev { get; set; }
}
