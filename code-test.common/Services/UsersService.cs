using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services.Results;
using Newtonsoft.Json;
using RestSharp;

namespace code_test.common.Services
{
    public class UsersService : IUsersService
    {
        private const string BaseUrl = "http://localhost:7070/api/users";
        
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var client = new RestClient(BaseUrl);
            
            var request = new RestRequest("/", Method.GET);

            var response = await client.ExecuteTaskAsync(request);
            
            var content = JsonConvert.DeserializeObject<GetAllUsersResult>(response.Content);
            
            return content.Users;
        }
    }
}