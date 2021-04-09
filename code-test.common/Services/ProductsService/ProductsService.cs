using System.Collections.Generic;
using System.Threading.Tasks;
using code_test.common.Models;
using Newtonsoft.Json;
using RestSharp;

namespace code_test.common.Services.ProductsService
{
    public class ProductsService : BaseService, IProductsService
    {
        private const string ApiBase = "/api/products";
        
        public ProductsService(string baseUrl = "http://10.0.2.2:7070") : base(baseUrl)
        {
        }
        
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var request = new RestRequest($"{ApiBase}", Method.GET);

            var response = await Client.ExecuteAsync(request);

            // Response comes back as key valued array, use a class to assist in deserialization
            var content = JsonConvert.DeserializeObject<GetAllProductsResult>(response.Content);
            
            return content.Products;
        }
    }
}