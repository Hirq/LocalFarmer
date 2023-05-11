namespace LocalFarmer.Web.Services
{
    public interface IFarmhouseService
    {
        List<Farmhouse> Farmhouses { get; set;}
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<List<Farmhouse>> GetFarmhousesWithProducts();
        public Task<Farmhouse> GetFarmhouse(int id);
    }
}
