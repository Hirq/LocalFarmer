namespace LocalFarmer.Web.Services
{
    public interface IProductService
    {
        List<Product> Products { get; set;}
        public Task GetProducts();
        public Task GetProductsFarmhouse(int idFarmhouse);
        public Task<Product> GetProduct(int id);
    }
}
