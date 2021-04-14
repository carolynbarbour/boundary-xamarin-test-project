using System;
using Newtonsoft.Json;

namespace code_test.common.Models
{
    [JsonObject]
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("second_name")]
        public string SecondName { get; set; }
        
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonIgnore] public string DisplayName => $"{FirstName} {SecondName}";
    }
}