using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public abstract class ResultModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_url")]
        public string AppUrl { get; set; }
    }
}
