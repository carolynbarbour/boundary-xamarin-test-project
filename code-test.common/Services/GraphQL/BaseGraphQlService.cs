using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using MvvmCross;
using Newtonsoft.Json;

namespace code_test.common.Services
{
    public class BaseGraphQlService
    {
        private string API_ENDPOINT = "NOT_SET";
        
        protected string AUTH_TOKEN_KEY = "auth_token";

        protected ISecureStorageFacade SecureStorageFacade;
        
        protected BaseGraphQlService(string apiEndpoint, ISecureStorageFacade storageFacade)
        {
            SecureStorageFacade = storageFacade;
            API_ENDPOINT = apiEndpoint;
        }

        protected async Task<T> ExecuteQueryAsync<T>(string queryField, GraphQLRequest payload, bool requiresAuth = true)
        {
            try
            {
                var client = await ConstructClientForRequest(requiresAuth);
                var response = await client.SendQueryAsync<object>(payload);

                if ((response.Errors ?? Array.Empty<GraphQLError>()).Any())
                {
                    throw new Exception("Error executing GraphQL Request");
                }

                var stringResult = response.Data.ToString();


                stringResult = stringResult.Replace($"\"{queryField}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                var result = JsonConvert.DeserializeObject<T>(stringResult);

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                throw;
            }
        }

        private async Task<GraphQLHttpClient> ConstructClientForRequest(bool requiresAuth = true)
        {
            var client = new GraphQLHttpClient(API_ENDPOINT, new NewtonsoftJsonSerializer());

            if (requiresAuth)
            {
                var token = await SecureStorageFacade.GetKeyValue(AUTH_TOKEN_KEY);
                if (token == null)
                {
                    throw new Exception(
                        "No Auth Token has been set in SecureStorage and a request to a query that needs one was made!");
                }

                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;

        }
    }
}