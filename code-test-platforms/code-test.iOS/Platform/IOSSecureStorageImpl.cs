using System.Threading.Tasks;
using code_test.common.Services;
using Xamarin.Essentials;

namespace code_test.iOS.Platform
{
    public class IOSSecureStorageImpl : ISecureStorageFacade
    {
        public Task SetKeyValue(string key, string value)
        {
            return Task.FromResult(SecureStorage.SetAsync(key, value));
        }

        public async Task<string> GetKeyValue(string key)
        {
            var rValue = await SecureStorage.GetAsync(key);

            return rValue;
        }
    }
}