using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services.AuthService.Responses;

namespace code_test.common.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> SignUp(string firstName, string secondName, string email, string username, string password);

        Task<LoginResponse> Login(string username, string password);
    }
}