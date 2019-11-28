using System.Collections.Generic;
using code_test.common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace code_test.common.Services.ProductsService
{
    public class GetAllProductsResult
    {
        [JsonProperty("products")] 
        public IEnumerable<Product> Products;
    }
}