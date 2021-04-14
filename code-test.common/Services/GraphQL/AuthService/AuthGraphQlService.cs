using System;
using System.Linq;
using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services.AuthService.Responses;
using GraphQL;
using Xamarin.Essentials;

namespace code_test.common.Services.AuthService
{
    public class AuthGraphQlService : BaseGraphQlService, IAuthService
    {
        public AuthGraphQlService(ISecureStorageFacade storageFacade = null,string endpoint = "http://localhost:8088/api") : base(endpoint, storageFacade)
        {
            
        }
        
        public async Task<User> SignUp(string firstName, string secondName, string email, string username, string password)
        {
            var signUpRequest = new GraphQLRequest
                {
                    Query =
                        @"mutation newUserSignUp($firstName:String!, $secondName:String!, $emailAddress:String!, $password:String!, $username: String!) {
  signUp(input:{
    first_name:$firstName,
    second_name:$secondName,
    password:$password,
    username:$username,
    email_address:$emailAddress,
  }) {
    id
  }
}",
                    Variables = new
                    {
                        firstName,
                        secondName,
                        password,
                        username,
                        emailAddress = email,
                    }
                };

            // "signUp' is the name of the data object that will be returned, pass this along to the base function so it can be used as the node to deserialize from
            var response = await ExecuteQueryAsync<User>("signUp", signUpRequest, false);

            return response;
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            // As per schema, this api will return an access_token.

            var queryString = @"mutation loginWithUNPass($username: String!, $password: String!) {" +
                               "login(username: $username, password: $password) {" +
                               "access_token } }";

            var loginRequest = new GraphQLRequest
            {
                Query = queryString,
                Variables = new
                {
                    username,
                    password
                }
            };

            var response = await ExecuteQueryAsync<LoginResponse>("login", loginRequest, false);

            return response;
        }
    }
}