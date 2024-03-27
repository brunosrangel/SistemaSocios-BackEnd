namespace SistemaSocio.Service.interfaces
{

    public interface IEntityService<TEntity> where TEntity : IDocument
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(string id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(string id, TEntity entity);
        Task<bool> DeleteAsync(string id);
    }

}
