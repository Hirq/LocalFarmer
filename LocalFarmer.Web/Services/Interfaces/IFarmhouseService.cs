namespace LocalFarmer.Web.Services
{
    public interface IFarmhouseService
    {
        List<Farmhouse> Farmhouses { get; set;}
        public Task GetFarmhouses();
        public Task<Farmhouse> GetFarmhouse(int id);
    }
}
