using System;
using Newtonsoft.Json;

namespace BasecampApiNet.Models
{
    public class PeopleResultModel : ResultModelBase
    {
        [JsonProperty("identity_id")]
        public int IdentityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email_address")]
        public string Email { get; set; }

        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("trashed")]
        public bool IsTrashed { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("full_size_avatar_url")]
        public string AvatarUrlFullsize { get; set; }
    }
}
