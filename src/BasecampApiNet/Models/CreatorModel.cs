using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class CreatorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("fullsize_avatar_url")]
        public string AvatarUrlFullSize { get; set; }
    }
}
