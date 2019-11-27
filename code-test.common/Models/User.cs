using Newtonsoft.Json;

namespace code_test.common.Models
{
    /*
     * "id": 1,
            "first_name": "Chase",
            "second_name": "Warner",
            "email_address": "nulla.ante@vel.net",
            "username": "CWarner",
            "password": "password1",
            "is_active": true
     */
    public class User
    {
        // ToDo : Remove

        public User(int id, string firstName, string secondName, string emailAddress)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.EmailAddress = emailAddress;
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("second_name")]
        public string SecondName { get; set; }
        
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
    }
}