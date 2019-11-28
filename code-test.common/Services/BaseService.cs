using RestSharp;

namespace code_test.common.Services
{
    public class BaseService
    {
        protected string BaseUrl;

        protected RestClient Client;

        public BaseService(string baseUrl)
        {
            BaseUrl = baseUrl;
            Client = new RestClient(baseUrl);
        }
    }
}