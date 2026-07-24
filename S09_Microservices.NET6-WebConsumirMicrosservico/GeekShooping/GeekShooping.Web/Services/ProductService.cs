using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _client.PostAsJsonAsync(BasePath, product);
            if(response.IsSuccessStatusCode)
            {
                return await response.ReadContentAsync<ProductModel>();
            }
            throw new Exception($"Something went wrong calling the API");
        }   
        
        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _client.PutAsJsonAsync(BasePath, product);
            if(response.IsSuccessStatusCode)
            {
                return await response.ReadContentAsync<ProductModel>();
            }
            throw new Exception($"Something went wrong calling the API");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if(response.IsSuccessStatusCode)
            {
                return await response.ReadContentAsync<bool>();
            }
            throw new Exception($"Something went wrong calling the API");
        }

    }
}
