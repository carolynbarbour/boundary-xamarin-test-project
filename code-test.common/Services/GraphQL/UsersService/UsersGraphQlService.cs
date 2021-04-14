using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Models;
using GraphQL;

namespace code_test.common.Services
{
    public class UsersGraphQlService : BaseGraphQlService, IUsersService
    {
        public UsersGraphQlService(ISecureStorageFacade storageFacade = null, string endpoint = "http://localhost:8088/api") : base(endpoint, storageFacade)
        {
            
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var request =
                @"query {getUsers{id, is_active, first_name, second_name, second_name, email_address, username}}";

            var response = await ExecuteQueryAsync<IEnumerable<User>>("getUsers", new GraphQLRequest
            {
                Query = request
            });

            return response;
        }

        public async Task<User> GetById(string userId)
        {
            throw new NotImplementedException("This needs done.");
        }
    }
}