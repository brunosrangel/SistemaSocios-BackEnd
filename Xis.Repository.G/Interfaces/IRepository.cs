using System.Linq.Expressions;

namespace Xis.Repository.G.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            Task<TEntity> GetByIdAsync(object id);
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
            Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
            Task AddAsync(TEntity entity);
            Task AddRangeAsync(IEnumerable<TEntity> entities);
            Task RemoveAsync(TEntity entity);
            Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        }
    }
}