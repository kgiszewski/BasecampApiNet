using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class ProjectTodoListModel
    {
        [JsonProperty("remaining_count")]
        public string RemainingCount { get; set; }

        [JsonProperty("completed_count")]
        public string CompletedCount { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_url")]
        public string AppUrl { get; set; }
    }
}
