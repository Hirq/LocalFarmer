using System.Net.Http.Json;

namespace LocalFarmer.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set;} = new List<Product>();
        public Product Product { get; set; } = new Product();

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7290/api/Product/ListProducts");

            if (result != null)
            {
                Products = result;
            }
        }

        public async Task GetProductsFarmhouse(int idFarmhouse)
        {
            var result = await _http.GetFromJsonAsync<List<Product>>($"https://localhost:7290/api/Product/ListProductsFarmhouse/{idFarmhouse}");
            if (result != null)
            {
                Products = result;
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<Product>($"https://localhost:7290/api/Product/Product/{id}");
            if (result != null)
            {
                Product = result;
            }

            return Product;
        }

    }
}
