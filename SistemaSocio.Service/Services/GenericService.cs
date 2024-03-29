using MongoDB.Bson;
using SistemaSocio.Service.interfaces;

namespace SistemaSocio.Service.Services
{


    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : IDocument<ObjectId>
    {
        private readonly IMongoRepository<TEntity> _repository;

        public EntityService(IMongoRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _repository.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                // Document not found
               
                return default(TEntity);
            }

            entity.Id = existingEntity.Id; // Ensure the ID is preserved
            await _repository.ReplaceOneAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                // Document not found
                return false;
            }

            return await _repository.DeleteByIdAsync(id);
        }
    }

}
