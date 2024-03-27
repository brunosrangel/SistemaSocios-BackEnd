using System.Linq.Expressions;

namespace Xis.Services.G
{
    public interface IService<TEntityDTO> where TEntityDTO : class
    {
        public interface IService<TEntityDTO> where TEntityDTO : class
        {
            Task<IEnumerable<TEntityDTO>> GetAllAsync();
            Task<IEnumerable<TEntityDTO>> FindAsync(Expression<Func<TEntityDTO, bool>> predicate);
            Task<TEntityDTO> GetByIdAsync(object id);
            Task CreateAsync(TEntityDTO entity);
            Task UpdateAsync(TEntityDTO entity);
            Task DeleteAsync(object id);
        }
    }
}