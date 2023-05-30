﻿namespace LocalFarmer.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public ProductService(HttpClient http,
            IMapper mapper)
        {
            _http = http;
            _mapper = mapper;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; } = new Product();

        public async Task<List<Product>> GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7290/api/Product/ListProducts");

            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
        }

        public async Task<List<Product>> GetProductsFarmhouse(int idFarmhouse)
        {
            var result = await _http.GetFromJsonAsync<List<Product>>($"https://localhost:7290/api/Product/ListProductsFarmhouse/{idFarmhouse}");
            
            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<Product>($"https://localhost:7290/api/Product/Product/{id}");
           
            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
        }

        public async Task AddProduct(ProductDto dto, int idFarmhouse)
        {
            Product product = _mapper.Map<Product>(dto);
            await _http.PostAsJsonAsync<Product>($"https://localhost:7290/api/Product/Product/{idFarmhouse}", product);
        }
    }
}
