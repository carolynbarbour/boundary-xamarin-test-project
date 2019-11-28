using Newtonsoft.Json;

namespace code_test.common.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("second_name")]
        public string SecondName { get; set; }
        
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonIgnore] public string DisplayName => $"{FirstName} {SecondName}";
    }
}