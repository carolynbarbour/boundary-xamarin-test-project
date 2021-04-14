using Newtonsoft.Json;

namespace code_test.common.Services.AuthService.Responses
{
    public class LoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken;
    }
}