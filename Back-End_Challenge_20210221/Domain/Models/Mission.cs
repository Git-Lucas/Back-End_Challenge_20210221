using Newtonsoft.Json;

namespace Back_End_Challenge_20210221.Domain.Models
{
    public class Mission
    {
        public long Id { get; set; }

        [JsonProperty("launch_library_id")]
        public long? LaunchLibraryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? LaunchDesignator { get; set; }

        public string? Type { get; set; }

        public Orbit? Orbit { get; set; }
    }
}
