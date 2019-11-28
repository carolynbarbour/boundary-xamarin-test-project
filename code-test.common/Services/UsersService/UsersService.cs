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
    public class UsersService : BaseService, IUsersService
    {
        private const string ApiBase = "/api/users";
        
        public UsersService(string serviceUrl = "http://10.0.2.2:7070") : base(serviceUrl) { }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var request = new RestRequest($"{ApiBase}", Method.GET);

            var response = await Client.ExecuteTaskAsync(request);

            // Response comes back as key valued array, use a class to assist in deserialization
            var content = JsonConvert.DeserializeObject<GetAllUsersResult>(response.Content);
            
            return content.Users;
        }

        public async Task<User> GetById(string userId)
        {
            throw new NotImplementedException("This needs done.");
        }
    }
}