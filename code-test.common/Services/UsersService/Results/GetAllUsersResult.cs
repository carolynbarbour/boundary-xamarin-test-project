using System.Collections.Generic;
using code_test.common.Models;
using Newtonsoft.Json;

namespace code_test.common.Services.Results
{
    public class GetAllUsersResult
    {
        [JsonProperty("users")] 
        public List<User> Users { get; set; }
    }
}