using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;

namespace LocalFarmer.Repositories
{
    public class FarmhouseRepository : BaseRepository<Farmhouse>, IFarmhouseRepository
    {
        public FarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
