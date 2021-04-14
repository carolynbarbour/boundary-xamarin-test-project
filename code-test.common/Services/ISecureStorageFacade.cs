using System.Threading.Tasks;

namespace code_test.common.Services
{
    public interface ISecureStorageFacade
    {
        Task SetKeyValue(string key, string value);

        Task<string> GetKeyValue(string key);
    }
}