using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;

namespace LocalFarmer.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
