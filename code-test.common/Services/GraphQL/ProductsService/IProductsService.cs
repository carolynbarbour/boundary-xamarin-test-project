using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Models;

namespace code_test.common.Services.ProductsService
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}