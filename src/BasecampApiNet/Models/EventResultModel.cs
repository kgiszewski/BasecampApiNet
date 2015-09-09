using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class EventResultModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("eventable")]
        public EventableModel Eventable { get; set; }

        [JsonProperty("creator")]
        public CreatorModel Creator { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}
