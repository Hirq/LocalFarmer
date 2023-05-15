using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;

namespace LocalFarmer.Repositories
{
    public class FarmhouseRepository : BaseRepository<Farmhouse>, IFarmhouseRepository
    {
        public FarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }

        //TODO: Check
        public async Task<Farmhouse> GetByIdOrThrowAsync(int id)
        {
            var farmhouse = await GetSingleAsync(x => x.Id == id);

            if (farmhouse == null)
            {
                throw new ApplicationException($"Not found farmhouse {id}");
            }

            return farmhouse;
        }
    }
}
