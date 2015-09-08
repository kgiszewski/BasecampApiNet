using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class PersonTodoListResultModel : ResultModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("completed")]
        public bool IsCompleted { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("trashed")]
        public bool IsTrashed { get; set; }

        [JsonProperty("completed_count")]
        public int CompletedCount { get; set; }

        [JsonProperty("remaining_count")]
        public int RemainingCount { get; set; }

        [JsonProperty("assigned_todos")]
        public IEnumerable<TodoResultModel> AssignedTodos { get; set; }

        [JsonProperty("creator")]
        public CreatorModel Creator { get; set; }

        [JsonProperty("bucket")]
        public BucketModel Bucket { get; set; }
    }
}
