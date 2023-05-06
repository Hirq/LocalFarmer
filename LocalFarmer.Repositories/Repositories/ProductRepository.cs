using LocalFarmer.Data.Context;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories.Base;
using LocalFarmer.Repositories.Interfaces;

namespace LocalFarmer.Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
