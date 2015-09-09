using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class TodoResultModel : ResultModelBase
    {
        [JsonProperty("todolist_id")]
        public int TodoListId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        [JsonProperty("due_on")]
        public DateTime? DueOn { get; set; }

        [JsonProperty("completed_at")]
        public bool IsCompleted { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("trashed")]
        public bool IsTrashed { get; set; }

        [JsonProperty("creator")]
        public CreatorModel Creator { get; set; }

        [JsonProperty("assignee")]
        public AssigneeModel AssigneeModel { get; set; }

        //TODO: add todolist
    }
}
