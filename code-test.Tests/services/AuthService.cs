using System.Threading.Tasks;
using code_test.common.Services.AuthService;
using NUnit.Framework;

namespace code_test_unit_tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private IAuthService _authService;
        
        /*[SetUp]
        public void Init()
        {
            _productsService = new ProductsService("http://localhost:7070");
        }

        [Test]
        public async Task GetAllProductsReturnsAsExpected()
        {
            var response = await _productsService.GetAllProducts();
            
            CollectionAssert.IsNotEmpty(response);
        }
        */

        [SetUp]
        public void Init()
        {
            _authService = new AuthGraphQlService();
        }

        [Test]
        public async Task SignUpReturnsAsExpectedWhenValid()
        {
            var exFName = "Test";
            var exSName = "User";
            var exEmail = "test@somewhere.com";
            var exUname = "testuser";

            var response = await _authService.SignUp(exFName, exSName, exEmail, exUname, "password1");

            Assert.IsFalse(string.IsNullOrEmpty(response.Id.ToString()));
        }

        [Test]
        public async Task LoginReturnsWithAccessToken()
        {
            var response = await _authService.Login("testuser", "password1");
            
            Assert.IsFalse(string.IsNullOrEmpty(response.AccessToken));
        }
    }
}