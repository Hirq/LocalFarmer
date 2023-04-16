using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;

namespace LocalFarmer.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
