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
    }
}
