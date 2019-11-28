using Newtonsoft.Json;

namespace code_test.common.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }
    }
}