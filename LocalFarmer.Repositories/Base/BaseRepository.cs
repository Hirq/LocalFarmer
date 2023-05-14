using LocalFarmer.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LocalFarmer.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly LocalfarmerDbContext _context;

        public BaseRepository(LocalfarmerDbContext context)
        {
            _context = context;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> whereExpression)
        {
            return _context.Set<TEntity>().Where(whereExpression).Single();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await _context.Set<TEntity>().Where(whereExpression).SingleAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(whereExpression);
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().Where(whereExpression);
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query().SingleAsync();
        }
    }
}
