using System.Threading.Tasks;
using code_test.common.Services.ProductsService;
using NUnit.Framework;

namespace code_test_unit_tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductsService _productsService;

        [SetUp]
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
    }
}