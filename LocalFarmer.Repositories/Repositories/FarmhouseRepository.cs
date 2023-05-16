using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;
using System.Linq.Expressions;

namespace LocalFarmer.Repositories
{
    public class FarmhouseRepository : BaseRepository<Farmhouse>, IFarmhouseRepository
    {
        public FarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }

        public async Task<Farmhouse> GetByIdOrThrowAsync(int id, params Expression<Func<Farmhouse, object>>[] includeProperties)
        {
            var farmhouse = await GetFirstOrDefaultAsync(x => x.Id == id, includeProperties);

            if (farmhouse == null)
            {
                throw new ApplicationException($"Not found farmhouse {id}");
            }

            return farmhouse;
        }
    }
}
