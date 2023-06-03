namespace LocalFarmer.Web.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<List<Product>> GetProductsFarmhouse(int idFarmhouse);
        public Task<Product> GetProduct(int id);
        public Task AddProduct(ProductDto dto, int idFarmhouse);
        public Task EditProduct(ProductDto dto, int idFarmhouse);
    }
}
