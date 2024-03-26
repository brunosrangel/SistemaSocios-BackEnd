using SistemaSocio.Service.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaSocio.Service.Services
{


    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<TEntity>> GetAllEntities()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetEntityById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEntity(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateEntity(string id, TEntity entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }

        public async Task<bool> DeleteEntity(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}
