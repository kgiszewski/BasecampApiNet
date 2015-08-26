using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class ProjectResultModel : ResultModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_client_project")]
        public bool IsClientProject { get; set; }

        [JsonProperty("trashed")]
        public bool IsTrashed { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("draft")]
        public bool IsDraft { get; set; }

        [JsonProperty("template")]
        public bool IsTemplate { get; set; }

        [JsonProperty("last_event_at")]
        public DateTime LastEventAt { get; set; }

        [JsonProperty("starred")]
        public bool IsStarred { get; set; }
    }
}
