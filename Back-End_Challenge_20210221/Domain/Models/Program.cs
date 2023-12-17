using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Program
{
    public long Id { get; set; }

    public Uri? Url { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<Agency> Agencies { get; set; } = new();

    [JsonProperty("image_url")]
    public Uri? ImageUrl { get; set; }

    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }

    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }

    [JsonProperty("info_url")]
    public Uri? InfoUrl { get; set; }

    [JsonProperty("wiki_url")]
    public Uri? WikiUrl { get; set; }
}
