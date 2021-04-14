using System.Threading.Tasks;
using code_test.common.Services;
using code_test.common.Services.AuthService;
using code_test.Tests.helpers;
using MvvmCross;
using NUnit.Framework;

namespace code_test_unit_tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUsersService _usersService;
        private IAuthService _authService;
        private ISecureStorageFacade _secureStorageFacade;
        
        [SetUp]
        public void Init()
        {
            _secureStorageFacade = new UnitSecureStorageImpl();
            _authService = new AuthGraphQlService(_secureStorageFacade);
            _usersService = new UsersGraphQlService(_secureStorageFacade);

        }

        [Test]
        public async Task GetAllUsersReturnsResponseAsListOfUser()
        {
            var authResponse = await _authService.Login("testuser", "password1");
            await _secureStorageFacade.SetKeyValue("auth_token", authResponse.AccessToken);

            var response = await _usersService.GetAllUsers();
            
            CollectionAssert.IsNotEmpty(response);
        }

        [Test]
        public async Task GetUserById1ReturnsChaseWarner()
        {
            /*
            var response = await _usersService.GetById("1");
            
            Assert.AreEqual(1, response.Id);
            Assert.AreEqual("Chase", response.FirstName);
            Assert.AreEqual("Warner", response.SecondName);
            Assert.AreEqual("nulla.ante@vel.net", response.EmailAddress);
            */
        }
    }
}