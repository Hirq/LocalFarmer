using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;
using LocalFarmer.Repositories.Interfaces;

namespace LocalFarmer.Repositories.Repositories
{
    public class FarmhouseRepository : BaseRepository<Farmhouse>, IFarmhouseRepository
    {
        public FarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
