using LocalFarmer.Domain.Models;

namespace LocalFarmer.Services
{
    public interface IFarmhouseService
    {
        Task<List<Farmhouse>> GetFarmhouses();
    }
}
