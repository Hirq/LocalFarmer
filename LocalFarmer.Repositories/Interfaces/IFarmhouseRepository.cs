using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;
using System.Linq.Expressions;

namespace LocalFarmer.Repositories
{
    public interface IFarmhouseRepository : IBaseRepository<Farmhouse>
    {
        Task<Farmhouse> GetByIdOrThrowAsync(int id);
    }
}
