using Newtonsoft.Json;

public partial class Rocket
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("configuration")]
    public Configuration Configuration { get; set; }

    [JsonProperty("launcher_stage")]
    public List<object> LauncherStage { get; set; }

    [JsonProperty("spacecraft_stage")]
    public object SpacecraftStage { get; set; }
}
