using System.Linq.Expressions;

namespace LocalFarmer.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetSingle(Expression<Func<TEntity, bool>> whereExpression);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExpression);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
