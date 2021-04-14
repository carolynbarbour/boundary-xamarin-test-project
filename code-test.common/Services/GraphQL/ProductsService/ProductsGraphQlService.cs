using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Models;
using Newtonsoft.Json;
using RestSharp;

namespace code_test.common.Services.ProductsService
{
    public class ProductsGraphQlService : BaseGraphQlService, IProductsService
    {
        private const string ApiBase = "/api/products";

        public ProductsGraphQlService(string endpoint = "http://localhost:8088/api", ISecureStorageFacade storageFacade = null) : base(endpoint, storageFacade)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}