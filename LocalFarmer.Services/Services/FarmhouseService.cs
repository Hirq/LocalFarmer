using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories;

namespace LocalFarmer.Services
{
    internal class FarmhouseService : IFarmhouseService
    {
        private readonly IFarmhouseRepository _farmhouseRepository;
        public FarmhouseService(IFarmhouseRepository farmhouseRepository)
        {
            _farmhouseRepository = farmhouseRepository;
        }

        public async Task<List<Farmhouse>> GetFarmhouses()
        {
            var farmhouses = await _farmhouseRepository.GetAllAsync();

            return farmhouses.ToList();
        }
    }
}
