using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Models;

namespace code_test.common.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetById(string userId);
    }
}