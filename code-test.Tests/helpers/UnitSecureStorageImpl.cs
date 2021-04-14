using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Services;

namespace code_test.Tests.helpers
{
    public class UnitSecureStorageImpl: ISecureStorageFacade
    {
        private Dictionary<string, string> SomethingBasic;

        public UnitSecureStorageImpl()
        {
            SomethingBasic = new Dictionary<string, string>();
        }
        
        public Task SetKeyValue(string key, string value)
        {
            SomethingBasic.Add(key, value);
            return Task.CompletedTask;
        }

        public Task<string> GetKeyValue(string key)
        {
            SomethingBasic.TryGetValue(key, out var value);

            return Task.FromResult(value);
        }
    }
}