using LocalFarmer.Web.ViewModels;

namespace LocalFarmer.Web.Services
{
    public interface IFarmhouseService
    {
        List<Farmhouse> Farmhouses { get; set;}
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<List<Farmhouse>> GetFarmhousesWithProducts();

        //TODO
        public Task<List<FarmhouseViewModel>> GetFarmhousesWithProducts2();
        public Task<Farmhouse> GetFarmhouse(int id);
    }
}
