namespace LocalFarmer.Web.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task GetProductsFarmhouse(int idFarmhouse);
        public Task<Product> GetProduct(int id);
    }
}
